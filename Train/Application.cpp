#include "MyForm.h"

using namespace System;
using namespace System::Windows::Forms;
using namespace Train;

[STAThread]
void main(array<String^>^ args)
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	MyForm^ myForm = gcnew MyForm();
	Application::Run(myForm);

	PASSENGER^ passenger = myForm->Passenger;

	if (passenger != nullptr)
	{
		MessageBox::Show("Successful Authentication of " + passenger->FIRSTNAME + " " + passenger->LASTNAME, "Program.cpp", MessageBoxButtons::OK);
	}
	else
	{
		MessageBox::Show("Authentication Cancelled", "Program.cpp", MessageBoxButtons::OK);
	}
}
