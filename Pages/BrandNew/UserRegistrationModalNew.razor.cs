using Microsoft.AspNetCore.Components;
using BlazorBEADs.Factories;
using BlazorBEADs.Interfaces.BEADs;
using BlazorBEADs.DemoWasm.Models;
using BlazorBEADs.Utilities;

namespace BlazorBEADs.DemoWasm.Pages.BrandNew
{
    public partial class UserRegistrationModalNew : ComponentBase
    {
        // --- Parameters ---
        [Parameter] public UserRegistrationModel Model { get; set; } = new();
        [Parameter] public EventCallback OnClose { get; set; }

        // --- Modal State ---
        protected bool IsVisible { get; private set; } = false;
        protected List<IRenderable> Elements { get; private set; } = [];

        // --- Options for Select and Radio fields ---
        private readonly List<Option> CountryOptions = new()
        {
            new("Italy", "IT"),
            new("United States", "US"),
            new("United Kingdom", "UK")
        };

        private readonly List<Option> GenderOptions = new()
        {
            new("Male", "Male"),
            new("Female", "Female"),
            new("Other", "Other")
        };

        // --- Modal Lifecycle ---
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Elements = CreateRenderableElements();
        }

        // --- Methods ---
        /// <summary>
        /// Opens the modal.
        /// </summary>
        public void Open()
        {
            IsVisible = true;
        }

        /// <summary>
        /// Closes the modal and triggers the appropriate lifecycle methods.
        /// </summary>
        public async Task Close()
        {
            IsVisible = false;
            await OnClose.InvokeAsync();
        }

        /// <summary>
        /// Submits the form within the modal, triggering validation, submission logic, and closure.
        /// </summary>
        protected async Task OnSubmitAsync()
        {
            await Close();
        }

        private List<IRenderable> CreateRenderableElements()
        {
            return
            [
                CreateFullNameElement(),
                CreateCountryElement(),
                CreateAcceptTermsElement(),
                CreateGenderElement()
            ];
        }

        // --- Element Builders ---
        private IRenderable CreateFullNameElement()
        {
            return BeadBuilderFactory.CreateInputBeadBuilder("nomeInput")
                .WithLabel("Full Name")
                .WithBindToProperty(() => Model.FullName)
                .Properties.WithClass("form-control")
                .Properties.WithRequired(true)
                .Events.WithOnFocus(() => Console.WriteLine("Focus out event triggered."))
                .WithValidationFunc(() => Model.ValidateFullName(),"ok",
                                         "Full Name must be at least 5 characters long.")
                .Build();
        }

        private IRenderable CreateCountryElement()
        {
            return BeadBuilderFactory.CreateSelectBeadBuilder("country")
                .WithBindToProperty(() => Model.Country)
                .WithLabel("Country")
                .WithOptions(CountryOptions)
                .Properties.WithClass("form-control")
                .Properties.WithRequired(true)
                .Build();
        }

        private IRenderable CreateAcceptTermsElement()
        {
            return BeadBuilderFactory.CreateCheckboxBeadBuilder("acceptTerms")
            .WithBindToProperty(() => Model.AcceptTerms)
            .WithLabel("I Accept the Terms and Conditions")
            .Properties.WithClass("form-check-input")
            .Build();
        }

        private IRenderable CreateGenderElement()
        {
            return BeadBuilderFactory.CreateGroupedRadioBeadBuilder("genderGroup")
                .WithLabel("Gender")
                .WithOptions(GenderOptions)
                .WithBindToProperty(() => Model.Gender)
                .Properties.WithClass("form-check-input")
                .Build();
        }
    }
}