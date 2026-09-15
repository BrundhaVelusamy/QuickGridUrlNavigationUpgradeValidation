# QuickGrid URL navigation validation

This sample compares QuickGrid sorting and paging in static SSR and Interactive Server rendering modes. It intentionally contains no custom URL synchronization, JavaScript, or third-party packages so framework behavior remains visible.

## Pages

| Scenario | URL | Render mode |
| --- | --- | --- |
| QuickGrid Static SSR | `/quickgrid-static` | Static SSR (no `@rendermode`) |
| QuickGrid Interactive Server | `/quickgrid-interactive` | `InteractiveServer` |

Both pages use the same 17 in-memory records, four sortable property columns, a five-item page size, and `Paginator`.

## Required package

The .NET 10 baseline uses the existing package reference:

`Microsoft.AspNetCore.Components.QuickGrid` version `10.0.12`

When upgrading, change the target framework and QuickGrid package to matching publicly available .NET 11 versions. Do not mix major framework and QuickGrid package versions.

## Evidence to capture

For each page and each test pass:

1. Open browser developer tools and preserve the initial document response.
2. Record the initial address-bar URL.
3. Capture the rendered HTML under the page's `*-grid-evidence` element, including every column header.
4. Capture the rendered HTML under the page's `*-paginator-evidence` element.
5. Activate the **Name** column header once and record:
   - the address-bar URL;
   - the rendered header markup;
   - the first visible row;
   - whether a document request or interactive circuit activity occurred.
6. Activate **Name** again and capture the same evidence for the opposite sort direction.
7. Navigate to page 2 with the paginator and record:
   - the address-bar URL;
   - the paginator markup;
   - the first visible row;
   - whether a document request or interactive circuit activity occurred.
8. Use browser Back, then Forward. Record the URL, selected page, sort direction, and first visible row after each action.
9. Reload the final URL directly in a new tab and record whether the same grid state is restored.

Do not add query-string handling to the sample. A failure to navigate or restore state is validation evidence.

## Validation passes

### 1. .NET 10 baseline

1. Confirm the project targets `net10.0` and references the matching 10.x QuickGrid package.
2. Run the app and complete the evidence checklist for both pages.
3. Expected Interactive Server baseline: sorting and paging update component state without adding QuickGrid state to browser history.
4. For static SSR, record whether controls are navigable and whether the URL changes. Do not add interactivity as a workaround.

### 2. .NET 11 upgrade

1. Install a supported .NET 11 SDK from the public .NET distribution channel.
2. Change `TargetFramework` to `net11.0`.
3. Change the QuickGrid package to the matching publicly available 11.x version.
4. Build before making any other changes.
5. Complete the evidence checklist for both pages.
6. Expected feature behavior to validate: sorting and paging participate in URL navigation, generated URLs are visible in rendered markup where applicable, and browser Back/Forward restores the corresponding grid state.
7. Compare all markup and URLs with the .NET 10 evidence.

If the public .NET 11 package API or behavior does not support these steps, stop and report the compiler output and captured markup rather than implementing custom navigation.

### 3. Compatibility switch

Do not add a switch until its exact name, value semantics, and supported scope are present in public documentation.

Based on standard public .NET configuration mechanisms, an AppContext compatibility switch would most likely be configured either:

- in the project file as a `RuntimeHostConfigurationOption`, which emits a `runtimeconfig.json` `configProperties` value; or
- at process startup with `AppContext.SetSwitch` before Blazor services and endpoints are configured, if the switch documentation explicitly permits programmatic configuration.

Prefer the project/runtime configuration location for published-output validation. After applying the documented switch, rebuild and repeat the full evidence checklist for both pages. Capture the generated `.runtimeconfig.json` as evidence that the setting reached published output.

### 4. Published output

From the project directory:

`dotnet publish -c Release -o artifacts/publish`

Run the application from `artifacts/publish`, then repeat the checklist for both pages. Capture the published `.runtimeconfig.json`, application URL, and rendered markup.

### 5. Trimmed publish

From the project directory:

`dotnet publish -c Release -p:PublishTrimmed=true -o artifacts/publish-trimmed`

Treat trim warnings or publish failures as validation results. Do not suppress warnings or add preservation directives unless public documentation requires them. If publish succeeds, run the trimmed output and repeat the checklist for both pages.

## Comparison record

For each pass, record:

- SDK version (`dotnet --version`)
- target framework
- QuickGrid package version
- compatibility switch state
- Debug, Release publish, or trimmed publish
- page/render mode
- initial URL
- sort ascending URL
- sort descending URL
- page 2 URL
- Back result
- Forward result
- direct-load result
- header markup
- paginator markup
- console, server, build, and publish errors
