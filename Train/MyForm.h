﻿#pragma once
#include "C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.7.2/System.Data.dll"
#include "C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.7.2/System.Data.dll"
#include "PASSENGER.h"


using namespace System::Data::SqlClient;

namespace Train {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::TextBox^ tbEmail;
	private: System::Windows::Forms::TextBox^ tbPassword;
	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::Button^ btnConfirm;
	private: System::Windows::Forms::Button^ btnCancel;


	protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container^ components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->tbEmail = (gcnew System::Windows::Forms::TextBox());
			this->tbPassword = (gcnew System::Windows::Forms::TextBox());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->btnConfirm = (gcnew System::Windows::Forms::Button());
			this->btnCancel = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->Font = (gcnew System::Drawing::Font(L"Tahoma", 26));
			this->label1->Location = System::Drawing::Point(12, 9);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(728, 74);
			this->label1->TabIndex = 0;
			this->label1->Text = L"LogIn";
			this->label1->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			this->label1->Click += gcnew System::EventHandler(this, &MyForm::label1_Click);
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(30, 117);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(79, 33);
			this->label2->TabIndex = 1;
			this->label2->Text = L"Email";
			// 
			// tbEmail
			// 
			this->tbEmail->Location = System::Drawing::Point(181, 117);
			this->tbEmail->Name = L"tbEmail";
			this->tbEmail->Size = System::Drawing::Size(529, 40);
			this->tbEmail->TabIndex = 2;
			// 
			// tbPassword
			// 
			this->tbPassword->Location = System::Drawing::Point(181, 189);
			this->tbPassword->Name = L"tbPassword";
			this->tbPassword->Size = System::Drawing::Size(529, 40);
			this->tbPassword->TabIndex = 4;
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(30, 189);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(128, 33);
			this->label3->TabIndex = 3;
			this->label3->Text = L"Password";
			// 
			// btnConfirm
			// 
			this->btnConfirm->Location = System::Drawing::Point(193, 266);
			this->btnConfirm->Name = L"btnConfirm";
			this->btnConfirm->Size = System::Drawing::Size(184, 46);
			this->btnConfirm->TabIndex = 5;
			this->btnConfirm->Text = L"login";
			this->btnConfirm->UseVisualStyleBackColor = true;
			this->btnConfirm->Click += gcnew System::EventHandler(this, &MyForm::button1_Click);
			// 
			// btnCancel
			// 
			this->btnCancel->Location = System::Drawing::Point(457, 266);
			this->btnCancel->Name = L"btnCancel";
			this->btnCancel->Size = System::Drawing::Size(184, 46);
			this->btnCancel->TabIndex = 6;
			this->btnCancel->Text = L"Cancel";
			this->btnCancel->UseVisualStyleBackColor = true;
			this->btnCancel->Click += gcnew System::EventHandler(this, &MyForm::button2_Click);
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(15, 33);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::SystemColors::ActiveBorder;
			this->ClientSize = System::Drawing::Size(752, 345);
			this->Controls->Add(this->btnCancel);
			this->Controls->Add(this->btnConfirm);
			this->Controls->Add(this->tbPassword);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->tbEmail);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Font = (gcnew System::Drawing::Font(L"Tahoma", 16));
			this->Margin = System::Windows::Forms::Padding(7, 6, 7, 6);
			this->Name = L"MyForm";
			this->Text = L"LogIn-Form";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void label1_Click(System::Object^ sender, System::EventArgs^ e) {
	}
	public: PASSENGER^ Passenger = nullptr;
	private: System::Void button1_Click(System::Object^ sender, System::EventArgs^ e) {
		
		String^ email = this->tbEmail->Text;
		String^ password = this->tbPassword->Text;

		if (email->Length == 0 || password->Length == 0) {
			MessageBox::Show("Please enter email and password",
				"Email or Password Empty", MessageBoxButtons::OK);
			return;
		}

		try {
			String^ connString = "Data Source=MEDO;Initial Catalog=TrainBooking;Integrated Security=True";
			SqlConnection sqlConn(connString);
			sqlConn.Open();

			String^ sqlQuery = "SELECT * FROM PASSENGER WHERE EMAIL=@email AND PASSWORD=@pwd;";
			SqlCommand command(sqlQuery, % sqlConn);
			command.Parameters->AddWithValue("@email", email);
			command.Parameters->AddWithValue("@pwd", password);

			SqlDataReader^ reader = command.ExecuteReader();
			if (reader->Read()) {
				
				Passenger = gcnew PASSENGER();
				Passenger->PASSENGERID = reader->GetInt32(0);
				Passenger->BOOKINGNUMBER = reader->GetInt32(1);
				Passenger->BOO_BOOKINGNUMBER = reader->GetInt32(2);
				Passenger->FIRSTNAME = reader->GetString(3);
				Passenger->LASTNAME = reader->GetString(4);
				Passenger->EMAIL = reader->GetString(5);
				Passenger->ARIACODE = reader->GetFloat(6);
				Passenger->NUMBER = reader->GetString(7);
				Passenger->PASSWORD = reader->GetString(8);
				Passenger->GENDER = reader->GetString(9);
				this->Close();
			}
			else {
				MessageBox::Show("Email or password is incorrect",
					"Email or Password Error", MessageBoxButtons::OK);
			}
		}
		catch (Exception^ e) {
			MessageBox::Show("Failed to connect to database",
				"Database Connection Error", MessageBoxButtons::OK);
		}
	}

private: System::Void button2_Click(System::Object^ sender, System::EventArgs^ e) {
	this->Close();
}
};
}