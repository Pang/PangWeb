using Microsoft.AspNetCore.Components;
using PangWeb.Services;
using PangWeb.Shared;

namespace PangWeb.Pages.Components.AdminPage
{
    public partial class EditBlogDialogComponent
    {
        [Parameter]
        public EventCallback<int> OnModalClose { get; set; }
        [Inject]
        private BlogService _blogService { get; set; }
        private Blog EditBlogForm;
        private bool showDeleteDialog;


        private int _selectedId;
        [Parameter]
        public int SelectedId
        {
            get { return _selectedId; }
            set
            {
                _selectedId = value;
                if (value > 0) EditBlogForm = _blogService.GetBlogById(value);
            }
        }
    }
}
