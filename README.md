# CG.Blazor.Forms._MudBlazor: 

---
[![Build Status](https://dev.azure.com/codegator/CG.Blazor.Forms._MudBlazor/_apis/build/status/CodeGator.CG.Blazor.Forms._MudBlazor?branchName=main)](https://dev.azure.com/codegator/CG.Blazor.Forms._MudBlazor/_build/latest?definitionId=74&branchName=main)
[![Github docs](https://img.shields.io/static/v1?label=Documentation&message=online&color=blue)](https://codegator.github.io/CG.Blazor.Forms._MudBlazor/index.html)
[![NuGet downloads](https://img.shields.io/nuget/dt/CG.Blazor.Forms._MudBlazor.svg?style=flat)](https://nuget.org/packages/CG.Blazor.Forms._MudBlazor)
![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/codegator/CG.Blazor.Forms._MudBlazor/74)
[![Github discussion](https://img.shields.io/badge/Discussion-online-blue)](https://github.com/CodeGator/CG.Blazor.Forms._MudBlazor/discussions)
[![CG.Blazor.Forms._MudBlazor on fuget.org](https://www.fuget.org/packages/CG.Blazor.Forms._MudBlazor/badge.svg)](https://www.fuget.org/packages/CG.Blazor.Forms._MudBlazor)

#### What does it do?
The package contains MudBlazor extensions for the CG.Blazor.Forms package.

#### Commonly used types:
* CG.Blazor.Forms.Attributes.MudBlazorAttribute
* CG.Blazor.Forms.Attributes.RenderMudAlertAttribute
* CG.Blazor.Forms.Attributes.RenderMudAutocompleteAttribute
* CG.Blazor.Forms.Attributes.RenderMudCheckBoxAttribute
* CG.Blazor.Forms.Attributes.RenderMudColorPickerAttribute
* CG.Blazor.Forms.Attributes.RenderMudDatePickerAttribute
* CG.Blazor.Forms.Attributes.RenderMudFieldAttribute
* CG.Blazor.Forms.Attributes.RenderMudNumericFieldAttribute
* CG.Blazor.Forms.Attributes.RenderMudRadioGroupAttribute
* CG.Blazor.Forms.Attributes.RenderMudSelectAttribute
* CG.Blazor.Forms.Attributes.RenderMudSliderAttribute
* CG.Blazor.Forms.Attributes.RenderMudSwitchAttribute
* CG.Blazor.Forms.Attributes.RenderMudTextFieldAttribute
* CG.Blazor.Forms.Attributes.RenderMudTimePickerAttribute

#### What platform(s) does it support?
* .NET 6.x or higher

#### How do I install it?
The binary is hosted on [NuGet](https://www.nuget.org/packages/CG.Blazor.Forms._MudBlazor). To install the package using the NuGet package manager:

PM> Install-Package CG.Blazor.Forms._MudBlazor

#### How do I contact you?
If you've spotted a bug in the code please use the project Issues [HERE](https://github.com/CodeGator/CG.Blazor.Forms._MudBlazor/issues)

We have a discussion group [HERE](https://github.com/CodeGator/CG.Blazor.Forms._MudBlazor/discussions)

#### Is there any documentation?
There is developer documentation [HERE](https://codegator.github.io/CG.Blazor.Forms._MudBlazor/)

We also blog about projects like this one on our website, [HERE](http://www.codegator.com)

---

#### How do I get started?

There is a working quick start sample [HERE](https://github.com/CodeGator/CG.Blazor.Forms._MudBlazor/tree/main/samples/CG.Blazor.Forms._MudBlazor.QuickStart) 

Steps to get started:

1. Create a Blazor project to get started.

2. Add MudBlazor to the project, since MudBlazor is (so far) the only supported UI package. [HERE](https://mudblazor.com/getting-started/installation#manual-install) is a good link to get started with MudBlazor.

3. Add the CG.Blazor.Forms._MudBlazor NUGET package to the project.

4. Add `@using CG.Blazor.Forms._MudBlazor` to the _Imports.razor file.

5. Add `<DynamicForm Model="@Model" OnValidSubmit="OnValidSubmit"/>` to the razor component where you want your dynamic form generated. Note that `Model` is a reference to your POCO object, and `OnValidSubmit` is a reference to your form's submit handler.

6. Add `services.AddMudBlazorFormGeneration();` to the `ConfigureServices` method of the `Startup` class.

7. Create your model type. Use attributes from the NUGET package to decorate any properties you want to be rendered on the form. Here is an example:

```
public class MyForm
{
	[RenderMudTextField]
	[Required]
	public string FirstName { get; set; }

	[RenderMudTextField]
	[Required]
	public string LastName { get; set; }

	[RenderMudDatePicker]
	public DateTime? DateOfBirth { get; set; }
}
```

That's pretty much it! You can, of course, get fancier, but that's up to you.




