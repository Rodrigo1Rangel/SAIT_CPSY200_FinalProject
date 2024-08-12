﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VillageRentalsMS.Domain.Managers;
using VillageRentalsMS.Domain;
using System.Data.OracleClient;

namespace VillageRentalsMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vR_Dataset.VR_CATEGORIES' table. You can move, or remove it, as needed.
            this.vR_CATEGORIESTableAdapter.Fill(this.vR_Dataset.VR_CATEGORIES);
            // TODO: This line of code loads data into the 'vR_Dataset.VR_RENTALEQUIPMENT' table. You can move, or remove it, as needed.
            this.vR_RENTALEQUIPMENTTableAdapter.Fill(this.vR_Dataset.VR_RENTALEQUIPMENT);
            // TODO: This line of code loads data into the 'vR_Dataset.VR_EQUIPMENT' table. You can move, or remove it, as needed.
            this.vR_EQUIPMENTTableAdapter.Fill(this.vR_Dataset.VR_EQUIPMENT);

        }

        // ======================================== ADD NEW EQUIPMENT ========================================
        private void Inventory_AddEquipment(object sender, EventArgs e) {}
        private void txtbxEquipDesc_TextChanged(object sender, EventArgs e) {}
        private void tabPage1_Click(object sender, EventArgs e) {}
        private void btn_AddEquipment(object sender, EventArgs e)
        {
            string category_description = this.addEquipment_category_id.Text;
            string category_id = this.addEquipment_category_id.SelectedValue.ToString();
            string equipment_description = txt_AddEquipDescription.Text;
            string equipment_name = txtAddEquip_Name.Text;

            InventoryManager.AddEquipment(category_id, equipment_description, equipment_name);
            
            Form1_Load(null, null);

            MessageBox.Show($"Equipment update:\n\n{equipment_name} equipment was added!");
        }


        // ========================================= ADD NEW CATEGORY =========================================
        private void btnAddCat_Click(object sender, EventArgs e)
        {
            string new_category_description = txt_AddCategory.Text;

            InventoryManager.AddCategory(new_category_description);

            Form1_Load(null, null);

            MessageBox.Show($"Category update:\n\n{new_category_description} category was added!");
        }
        private void txt_AddCategory_TextChanged(object sender, EventArgs e) {}


        // ========================================= REMOVE EQUIPMENT =========================================
        private void datagridEquipment_CellContentClick(object sender, DataGridViewCellEventArgs e) {}

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            string equipment_id_to_remove = txt_RemoveEquipmentID.Text;
            InventoryManager.RemoveEquipment(equipment_id_to_remove);
            Form1_Load(null, null);
        }

        private void label2_Click(object sender, EventArgs e) {}

        private void textBox3_TextChanged(object sender, EventArgs e) {}

        // ========================================== REMOVE CATEGORY ==========================================
        private void label5_Click(object sender, EventArgs e) {}

        private void txt_category_id_to_remove_TextChanged(object sender, EventArgs e) {}

        private void btn_RemoveCatategory_Click(object sender, EventArgs e)
        {
            string category_id_to_remove = txt_category_id_to_remove.Text;
            InventoryManager.RemoveCategory(category_id_to_remove);
            Form1_Load(null, null);
        }
    }
}
