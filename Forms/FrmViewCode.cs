using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml;
using StarPrismTools.Infrastructure;
using StarPrismTools.Models;

namespace StarPrismTools.Forms
{
	public partial class FrmViewCode : Form
	{
		private static readonly Encoding Utf8WithoutBom = new UTF8Encoding(false);
		private readonly Func<string, OperationResult<Character>> saveHandler;
		private bool editMode;

		public FrmViewCode()
		{
			InitializeComponent();
			InitializeView(null, null);
		}

		public FrmViewCode(Character character, Func<string, OperationResult<Character>> saveHandler)
		{
			InitializeComponent();
			this.saveHandler = saveHandler;
			InitializeView(character, saveHandler);
		}

		public Character SavedCharacter { get; private set; }

		private void InitializeView(Character character, Func<string, OperationResult<Character>> handler)
		{
			txtJsonCode.Text = character == null ? string.Empty : SerializePretty(character);
			txtJsonCode.Enabled = true;
			txtJsonCode.ReadOnly = true;
			txtJsonCode.WordWrap = false;
			btnEditSave.Text = "Edit";
			btnEditSave.Enabled = handler != null && character != null;
			btnClose.Click += BtnClose_Click;
			btnEditSave.Click += BtnEditSave_Click;
		}

		private void BtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnEditSave_Click(object sender, EventArgs e)
		{
			if (!editMode)
			{
				editMode = true;
				txtJsonCode.ReadOnly = false;
				btnEditSave.Text = "Save";
				txtJsonCode.Focus();
				return;
			}

			OperationResult<Character> saveResult = saveHandler == null
				? OperationResult<Character>.Fail("No save handler is available.")
				: saveHandler(txtJsonCode.Text);
			if (!saveResult.Success)
			{
				MessageBox.Show(this, saveResult.Message, "StarPrism Tools", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			SavedCharacter = saveResult.Value;
			txtJsonCode.Text = SerializePretty(SavedCharacter);
			txtJsonCode.ReadOnly = true;
			editMode = false;
			btnEditSave.Text = "Edit";
			MessageBox.Show(this, "Character JSON saved.", "StarPrism Tools", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public static OperationResult<Character> ParseCharacter(string json)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(json))
				{
					return OperationResult<Character>.Fail("JSON content is empty.");
				}

				using (MemoryStream stream = new MemoryStream(Utf8WithoutBom.GetBytes(json)))
				{
					DataContractJsonSerializer serializer = CreateSerializer(typeof(Character));
					Character character = (Character)serializer.ReadObject(stream);
					if (character == null || string.IsNullOrWhiteSpace(character.Id))
					{
						return OperationResult<Character>.Fail("Character JSON must contain an Id.");
					}

					return OperationResult<Character>.Ok(character);
				}
			}
			catch (Exception ex)
			{
				return OperationResult<Character>.Fail("Invalid character JSON.", ex);
			}
		}

		public static string SerializePretty(Character character)
		{
			using (MemoryStream rawStream = new MemoryStream())
			{
				CreateSerializer(typeof(Character)).WriteObject(rawStream, character);
				rawStream.Position = 0;

				using (XmlDictionaryReader reader = JsonReaderWriterFactory.CreateJsonReader(rawStream, XmlDictionaryReaderQuotas.Max))
				using (MemoryStream formattedStream = new MemoryStream())
				using (XmlDictionaryWriter writer = JsonReaderWriterFactory.CreateJsonWriter(formattedStream, Utf8WithoutBom, false, true))
				{
					writer.WriteNode(reader, true);
					writer.Flush();
					return Utf8WithoutBom.GetString(formattedStream.ToArray());
				}
			}
		}

		private static DataContractJsonSerializer CreateSerializer(Type type)
		{
			return new DataContractJsonSerializer(type, new DataContractJsonSerializerSettings
			{
				UseSimpleDictionaryFormat = true
			});
		}
	}
}
