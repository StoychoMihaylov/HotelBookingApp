using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using RTE;

namespace rtedemo.Controllers
{
	public class MyModel
	{
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*")]
		public string Title { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*")]
		public string Message { get; set; }

		[System.ComponentModel.DataAnnotations.RegularExpression("True",ErrorMessage="You must accept it.")]
		[System.ComponentModel.DataAnnotations.Display(Name="I accept it.")]
		public bool Accept { get; set; }
	}

	[ValidateInput(false)]
	public class CsModelController : Controller
	{
		//this is a custom function that create and initialize the editor
		protected Editor PrepairEditor(string propertyName,Action<Editor> oninit)
		{
			Editor editor = new Editor(System.Web.HttpContext.Current, propertyName);

			editor.ClientFolder = "/richtexteditor/";
			editor.ContentCss = "/Content/example.css";
			//editor.ClientFolder = "/Content/richtexteditor/";
			//editor.ClientFolder = "/Scripts/richtexteditor/";

			//editor.Text = "Type here";

			editor.AjaxPostbackUrl = Url.Action("EditorAjaxHandler");

			if (oninit != null) oninit(editor);

			//try to handle the upload/ajax requests
			bool isajax = editor.MvcInit();

			if (isajax)
				return editor;

			//load the form data if any
			if (this.Request.HttpMethod == "POST")
			{
				string formdata = this.Request.Form[editor.Name];
				if (formdata != null)
					editor.LoadFormData(formdata);
			}

			//render the editor to ViewBag.Editor
			ViewBag.Editor = editor.MvcGetString();

			return editor;
		}

		//this action is specified by editor.AjaxPostbackUrl = Url.Action("EditorAjaxHandler");
		//it will handle the editor dialogs Upload/Ajax requests
		[ValidateInput(false)]
		public ActionResult EditorAjaxHandler()
		{
			PrepairEditor("Message",delegate(Editor editor)
			{

			});
			return new EmptyResult();
		}

		[ValidateInput(false)]
		public ActionResult PostToModel()
		{
			PrepairEditor("Message", delegate(Editor editor)
			{
				//set editor properties here
			});
			return View(new MyModel());
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult PostToModel(MyModel model)
		{
			Editor theeditor = PrepairEditor("Message", delegate(Editor editor)
			{
				//set editor properties here
			});

			model.Message = theeditor.ApplyFilter(model.Message);
			
			//or use , while the LoadFormData is called
			//model.Message = theeditor.Text;

			//check the editor data here

			if (ModelState.IsValid)
			{
				//TODO , save the data to DB , and redirect to result page..
			}

			return View(model);
		}



	}
}
