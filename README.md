# QuickGrid URL Navigation Upgrade Validation

This repository contains sample applications, validation assets, and evidence used to validate ASP.NET Core Issue #69132 - **What QuickGrid's URL Navigation Changes for an Existing App**.

## Repository Purpose

The samples in this repository validate the behavior changes introduced when upgrading QuickGrid from .NET 10 to .NET 11, with a focus on URL-based sorting and paging.

## Contents

- .NET 10 baseline sample application
- .NET 11 upgraded sample application
- Static SSR QuickGrid validation scenarios
- Interactive Server QuickGrid validation scenarios
- Validation report and test results
- Screenshots and HTML evidence
- Published output validation evidence
- Trimmed publish investigation results
- Documentation assessment findings

## Validation Scenarios

### .NET 10 Baseline

- Capture sortable header markup
- Capture paginator markup
- Verify Static SSR behavior
- Verify Interactive Server behavior
- Record URL behavior
- Record UI selectors

### .NET 11 Upgrade

- Verify URL-based sorting
- Verify URL-based paging
- Verify URL-state restoration
- Verify browser Back and Forward navigation
- Compare rendered markup with .NET 10 baseline
- Validate manual URL navigation scenarios

### Compatibility Switch Validation

- Verify restoration of button-based rendering
- Verify paginator button rendering
- Verify behavior after removing the switch
- Compare rendered markup before and after switch application

### Publish Validation

- Normal Publish
- Published Output Verification
- URL Navigation Verification
- Compatibility Switch Verification

### Trimmed Publish Investigation

- PublishTrimmed validation
- Build warning review
- Runtime exception investigation
- Reproduction against additional Blazor samples
- Documentation of blocking issue

## Prerequisites

- .NET SDK 11.0.100-rc.1.26425.128
- Visual Studio 2026 Preview (or later)

The repository uses a global.json file to ensure consistent SDK resolution and reproducible validation results.

## Repository Structure

```text
QuickGridUrlNavigationUpgradeValidation
│
├── Samples
│   └── QuickGridUrlNavigationSampleNET10To11
│
├── Evidence
│   ├── SSR
│   ├── Server
│   ├── Trimmed issue
│   └── ValidationReport
│
└── README.md
```

## Deployment / Running the Samples
```
    git clone https://github.com/BrundhaVelusamy/QuickGridUrlNavigationUpgradeValidation.git

    cd QuickGridUrlNavigationUpgradeValidation

    cd Samples/QuickGridUrlNavigationSampleNET10To11

    dotnet restore

    dotnet build

    dotnet run
```
## Application URL

After running the application, the ASP.NET Core development server displays the active URL(s) in the console output.

Expected URL:

```text
https://localhost:5041

https://localhost:7122
```
Use the URL displayed by dotnet run if different.

## Publish Commands

### Normal Publish

```
dotnet publish .\QuickGridUrlNavigationSampleNET10To11.csproj ` -c Release ` -o .\artifacts\hosted-publish 

cd .\artifacts\hosted-publish 

$env:ASPNETCORE_ENVIRONMENT = "Production" 

dotnet .\QuickGridUrlNavigationSampleNET10To11.dll --urls http://localhost:5041
```
### Trimmed Publish

```
dotnet publish .\QuickGridUrlNavigationSampleNET10To11.csproj ` -c Release ` -p:PublishTrimmed=true ` -o .artifacts\trimmed-publish 

cd .\artifacts\trimmed-publish

$env:ASPNETCORE_ENVIRONMENT = "Production"

dotnet .\QuickGridUrlNavigationSampleNET10To11.dll --urls http://localhost:5041
```
## Validation Outcome

### Successfully Validated
* .NET 10 baseline behavior
* .NET 11 upgrade behavior
* Static SSR URL navigation
* Interactive Server URL navigation
* Browser Back and Forward navigation
* URL-state restoration
* Button-to-anchor rendering changes
* Compatibility switch behavior
* Published output behavior

### Trimmed Publish

The publish completed successfully but produced 15 trimming warnings. The warnings included explicit notices that Razor Components and Interactive Server components do not currently support trimming and Native AOT. During runtime, navigation to the application URL resulted in an unhandled exception before any QuickGrid validation scenarios could be executed. The server logs reported an InvalidOperationException indicating that a suitable constructor for the NotFound component could not be located.

Additional investigation was performed to determine whether the issue was specific to the QuickGrid validation sample. A newly created Blazor Web App using the default template reproduced the same startup failure when published with trimming enabled.

This is documented in the validation report and evidence artifacts.

## Outcome

The .NET 10 baseline validation, .NET 11 upgrade validation, Static SSR validation, Interactive Server validation, URL-navigation behavior, compatibility-switch validation, and normal published-output validation all passed successfully.

Trimmed publish validation remains blocked due to a reproducible runtime startup exception encountered after trimming. The same behavior was reproduced outside of the QuickGrid sample, indicating that the failure is not specific to the QuickGrid URL-navigation feature under validation.