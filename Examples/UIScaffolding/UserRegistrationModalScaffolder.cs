namespace BlazorBEADs.DemoWasm.Examples.UIScaffolding;
using BlazorBEADs.DemoWasm.Examples.Models;
using BlazorBEADs.Factories;
using BlazorBEADs.Interfaces.BEADs;

/// <summary>
/// Provides scaffolding functionality to generate user registration form fields dynamically as BEAD components.
/// </summary>
public static class UserRegistrationModalScaffolder
{
    /// <summary>
    /// Creates a list of BEAD components representing a registration form.
    /// </summary>
    /// <param name="model">The user registration model to bind to.</param>
    /// <param name="stateHasChanged">Delegate to trigger UI updates.</param>
    /// <returns>A list of dynamically generated BEAD components.</returns>
    public static List<IRenderable> CreateFormFields(UserRegistrationModel model, Action stateHasChanged) => 
    [
        // Creating the Input BEAD for Username input field
        BeadBuilderFactory.CreateInputBeadBuilder("usernameInput")
            // Setting the label displayed above the input field
            .WithLabel("Username")
            // Binding the input field to the UserName property in the model
            .WithBindToProperty(() => model.UserName)
            // Marking the field as required and setting a placeholder text
            .Properties.WithRequired(true)
            .Properties.WithPlaceholder("Enter your username")
            .Properties.WithClass("form-control")
            // Adding an event handler to log input completion
            .Events.WithOnBlur(() =>
            {
                Console.WriteLine("Username input completed!");
                stateHasChanged();
            })
            // Defining a validation rule to ensure a minimum length requirement
            .WithValidationFunc(() => model.ValidateUserName(), "", 
                "Username must be at least 5 characters long.")
            .Build(),

        // Creating the Checkbox BEAD for Accept Terms selection
        BeadBuilderFactory.CreateCheckboxBeadBuilder("acceptTerms")
            // Setting the label displayed next to the checkbox
            .WithLabel("I Accept the Terms and Conditions")
            // Binding the checkbox to the AcceptedTerms property in the model
            .WithBindToProperty(() => model.AcceptedTerms)
            .Properties.WithClass("form-check-input")
            // Adding an event handler to log checkbox changes
            .Events.WithOnChange(() =>
            {
                Console.WriteLine(model.AcceptedTerms ? "Terms accepted." : "Terms not accepted.");
                stateHasChanged();
            })
            .Build(),

        // Creating the Select BEAD for choosing a Country
        BeadBuilderFactory.CreateSelectBeadBuilder("country")
            // Setting the label displayed above the dropdown menu
            .WithLabel("Country")
            // Defining available options for country selection
            .WithOptions(
            [
                new("United States", "US"),
                new("Italy", "IT"),
                new("United Kingdom", "UK")
            ])
            // Binding the select input to the Country property in the model
            .WithBindToProperty(() => model.Country)
            .Properties.WithClass("form-control")
            // Adding an event handler to log selected country
            .Events.WithOnChange(() =>
            {
                Console.WriteLine("Country selected: " + model.Country);
                stateHasChanged();
            })
            .Build(),

        // Creating the Grouped Radio BEAD for selecting a Preferred Framework
        BeadBuilderFactory.CreateGroupedRadioBeadBuilder("frameworkGroup")
            // Setting the label displayed above the radio button group
            .WithLabel("Preferred Framework")
            // Defining available options for framework selection
            .WithOptions(
            [
                new("Blazor", "Blazor"),
                new("Angular", "Angular"),
                new("React", "React")
            ])
            // Binding the radio button selection to the SelectedFramework property in the model
            .WithBindToProperty(() => model.SelectedFramework)
            .Properties.WithClass("form-check-input")
            // Adding an event handler to log selected framework
            .Events.WithOnChange(() =>
            {
                Console.WriteLine("Framework selected: " + model.SelectedFramework);
                stateHasChanged();
            })
            .Build()
    ];
}