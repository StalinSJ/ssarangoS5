using ssarangoS5.Models;

namespace ssarangoS5.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.personRepo.AddNewPerson(txtName.Text);
        statusMessage.Text = App.personRepo.StatusMessage;

    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        List<Persona> people = App.personRepo.GetAllPerson();
        ListaPersona.ItemsSource = people;

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        if (ListaPersona.SelectedItem is Persona selectedPerson)
        {
            App.personRepo.DeletePerson(selectedPerson.Id);
            RefreshCollectionView();
        }
        else
        {
            statusMessage.Text = "Seleccione una persona para eliminar.";
        }
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        if (ListaPersona.SelectedItem is Persona selectedPerson)
        {
            // Obtén el valor actualizado del Entry (o cualquier otro control UI)
            string updatedName = txtUpdatedName.Text;

            Persona updatedPerson = new Persona
            {
                Id = selectedPerson.Id,
                Name = updatedName
            };

            App.personRepo.UpdatePerson(updatedPerson);
            RefreshCollectionView();
        }
        else
        {
            statusMessage.Text = "Seleccione una persona para actualizar.";
        }
    }

    private void RefreshCollectionView()
    {
       
        List<Persona> people = App.personRepo.GetAllPerson();
        ListaPersona.ItemsSource = people;
    }
}
