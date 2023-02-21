using BookReadLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookReadList
{
    public partial class BookReadUI : Form
    {
        private List<BookModel> books = TextSaveManager.LoadFile().ConvertToBookModels();

        public BookReadUI()
        {
            InitializeComponent();

            UpdateList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                BookModel book = new BookModel();
                book.Title = tbxTitle.Text;
                book.Author = tbxAuthor.Text;
                book.Publisher = tbxPublisher.Text;

                books.Add(book);

                TextSaveManager.SaveToFile(books);

                ClearTextBoxes();

                UpdateList();
            }
            else
            {
                MessageBox.Show("Something went wrong! Please check the fields and try again.");
            }
        }

        /// <summary>
        /// Clears the text boxes.
        /// </summary>
        private void ClearTextBoxes()
        {
            tbxTitle.Clear();
            tbxAuthor.Clear();
            tbxPublisher.Clear();
        }

        /// <summary>
        /// Validates the form by checking the lengthes of the texts inside text boxes.
        /// </summary>
        /// <returns>Returns true if validation is correct.</returns>
        private bool ValidateForm()
        {
            if (tbxTitle.Text.Length == 0)
            {
                return false;
            }

            if (tbxAuthor.Text.Length == 0)
            {
                return false;
            }

            if (tbxPublisher.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Updates Listbox.
        /// </summary>
        private void UpdateList()
        {
            lbxList.DataSource = null;
            lbxList.DataSource = books;
            lbxList.DisplayMember= "FullInfo";
        }

        /// <summary>
        /// Removes selected item in listbox from data file and books list.
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // TODO - ListBox'a seçili olan item'ın silinmesi yazılacak.

            BookModel book = (BookModel)lbxList.SelectedItem;

            books.Remove(book);

            TextSaveManager.SaveToFile(books);

            UpdateList();
        }
    }
}
