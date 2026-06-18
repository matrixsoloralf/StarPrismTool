# StarPrismTools

StarPrismTools is a WinForms data management tool for StarPrism.

The project is designed around two core decisions:

- JSON files are the application data source.
- Git is the synchronization layer for local and remote data.

## Architecture

Current module boundaries:

- `Models`: StarPrism domain objects. Add concrete data structures here when the schema is confirmed.
- `Data\Json`: low-level JSON file loading and saving.
- `Data\Repositories`: typed repositories that map domain models to JSON files.
- `Data\Git`: Git command wrapper for status, pull, commit, and push workflows.
- `Infrastructure`: app configuration, paths, and operation result types shared across layers.
- `Forms` and `Components`: WinForms UI only.

The UI should call services and repositories instead of reading JSON files or running Git commands directly.

## Data Flow

Expected flow after models are added:

1. UI asks a repository to load or save a specific domain model.
2. Repository maps that model to a JSON file path under the selected data repository.
3. `JsonFileStore` performs the file operation and returns an `OperationResult`.
4. Git sync features use `GitService` against the selected repository path.

## JSON Layout

StarPrism data should be stored as multiple JSON files inside one Git repository:

```text
manifest.json
characters/
  character_ur.json
skills/
  skill_ur_yongzhe_liezhan.json
assets/
  characters/
    ur/
      portrait.png
      illustration.png
      cards/
        00Ur.png
```

This layout is preferred over one large JSON file because it reduces Git merge conflicts and keeps each character, skill, and asset independently editable.

`manifest.json` is the entry point. It tracks available characters and skills, while each entity file stores the full editable data.

Characters reference skills through `SkillLinks`; they do not embed full skill definitions. This keeps reusable skills normalized and lets the UI load character cards and skill lists independently.

The repository includes `sample-data` for local UI verification. Use the main toolbar `Load` button and select that folder to preview the current bindings.

## Local Configuration

Local machine settings are saved as JSON under the application user data folder.

Default configurable values:

- `RepositoryPath`
- `RemoteUrl`
- `BranchName`
- `CommitAuthorName`
- `CommitAuthorEmail`
