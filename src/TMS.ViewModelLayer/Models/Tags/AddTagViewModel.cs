using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TMS.ModelLayer.People;

namespace TMS.ViewModelLayer.Models.Tags
{
    public class AddTagViewModel
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public long ObjectId { get; set; }

        [Display(Name = "Tag Name")]
        public long TagToAddId { get; set; }
        public SelectList Tags { get; set; }
        public PersonKey PersonKey { get; set; }
    }
}
