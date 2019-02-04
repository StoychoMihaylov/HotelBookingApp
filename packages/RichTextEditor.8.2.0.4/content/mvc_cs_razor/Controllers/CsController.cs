using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using RTE;

namespace rtedemo.Controllers
{
	[ValidateInput(false)]
	public class CsController : Controller
	{
		//this is a custom function that create and initialize the editor
		protected Editor PrepairEditor(Action<Editor> oninit)
		{
			Editor editor = new Editor(System.Web.HttpContext.Current, "editor");

			editor.ClientFolder = "/richtexteditor/";
			editor.ContentCss = "/Content/example.css";
			//editor.ClientFolder = "/Content/richtexteditor/";
			//editor.ClientFolder = "/Scripts/richtexteditor/";

			editor.Text = "Type here";

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
			PrepairEditor(delegate(Editor editor)
			{

			});
			return new EmptyResult();
		}

		[ValidateInput(false)]
		public ActionResult toolbar_editor()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult autoheight()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.Text = "This is some more test text.<br />This is some more test text.<br />This is some more test text.<br />This is some more test text.<br />This is some more test text.<br />This is some more test text.<br />This is some more test text.";

				string m = Request.QueryString["mode"];
				if (string.IsNullOrEmpty(m))
					m = "auto";
				switch (m)
				{
					case "auto":
						editor.ResizeMode = RTEResizeMode.AutoAdjustHeight;
						break;
					case "width":
						editor.ResizeMode = RTEResizeMode.ResizeWidth;
						break;
					case "height":
						editor.ResizeMode = RTEResizeMode.ResizeHeight;
						break;
					case "both":
						editor.ResizeMode = RTEResizeMode.ResizeBoth;
						break;
					case "no":
						editor.ResizeMode = RTEResizeMode.Disabled;
						break;
				}

				ViewBag.mode = m;

			});

			return View();
		}

		[ValidateInput(false)]
		public ActionResult contextmenumode()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult contextmenumode(string m = "")
		{
			PrepairEditor(delegate(Editor editor)
			{
				m = Request.Form["SelectType"];
				editor.ContextMenuMode = RTEContextMenuMode.Default;
				if (!string.IsNullOrEmpty(m))
				{
					if (m == "Minimal")
					{
						editor.ContextMenuMode = RTEContextMenuMode.Minimal;
					}
					if (m == "Simple")
					{
						editor.ContextMenuMode = RTEContextMenuMode.Simple;
					}
					ViewBag._mode = m;
				}

			});

			return View();
		}

		[ValidateInput(false)]
		public ActionResult custom_buttons()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.ToolbarItems = "{bold,italic,underlinemenu}{forecolor,backcolor,fontname,fontsize}{justifyleft,justifycenter,justifyright,justifyfull}{insertorderedlist,insertunorderedlist,outdent,indent}{insertlink,insertimage,insertblockquote,syntaxhighlighter}{unlink,removeformat}//{mybutton1}";
			});

			return View();
		}

		[ValidateInput(false)]
		public ActionResult custom_buttons2()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.ToolbarItems = "{bold,italic,underlinemenu}{forecolor,backcolor,fontname,fontsize}{justifyleft,justifycenter,justifyright,justifyfull}{insertorderedlist,insertunorderedlist,outdent,indent}{insertlink,insertimage,insertblockquote,syntaxhighlighter}{unlink,removeformat}//{mydialog1}";
			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult custom_css()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.ContentCss = "/Content/example.css,/Content/forecolor.css";
			});
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult custom_css(string m = "")
		{
			PrepairEditor(delegate(Editor editor)
			{
				m = Request.Form["SelectType"];
				if (!string.IsNullOrEmpty(m))
				{
					editor.ContentCss = "/Content/example.css," + m;
					ViewBag._mode = m;
				}
				else
					editor.ContentCss = "/Content/example.css,/Content/forecolor.css";
			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult dialog_editor()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult doctype()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult doctype(string m = "")
		{
			PrepairEditor(delegate(Editor editor)
			{
				m = Request.Form["SelectType"];
				string c = Request.Form["editor"];
				editor.DesignDocType = RTEDesignDocType.Default;
				if (!string.IsNullOrEmpty(m))
				{
					if (m == "HTML4")
					{
						editor.DesignDocType = RTEDesignDocType.HTML4;
					}
					if (m == "HTML5")
					{
						editor.DesignDocType = RTEDesignDocType.HTML5;
					}
					if (m == "XHTML")
					{
						editor.DesignDocType = RTEDesignDocType.XHTML;
					}
					ViewBag._mode = m;
				}
			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult entermode()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult entermode(string m = "")
		{
			PrepairEditor(delegate(Editor editor)
			{
				m = Request.Form["SelectType"];
				if (!string.IsNullOrEmpty(m))
				{
					if (m == "p")
					{
						editor.EnterKeyTag = RTEEnterKeyTag.P;
					}
					if (m == "br")
					{
						editor.EnterKeyTag = RTEEnterKeyTag.BR;
					}
					if (m == "div")
					{
						editor.EnterKeyTag = RTEEnterKeyTag.DIV;
					}
					ViewBag._mode = m;
				}
			});

			return View();
		}

		[ValidateInput(false)]
		public ActionResult filter_html()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult filter_html(string m = "")
		{
			PrepairEditor(delegate(Editor editor)
			{
				m = Request.Form["SelectType"];
				if (!string.IsNullOrEmpty(m))
				{
					if (m == "no")
					{
						editor.TagBlackList = "*";
					}
					if (m == "white")
					{
						editor.TagWhiteList = "embed";
					}
					if (m == "black")
					{
						editor.TagBlackList = "div";
					}
					if (m == "full")
					{
						editor.AllowScriptCode = true;
						editor.EditCompleteDocument = true;
						editor.TagBlackList = "";
					}
					ViewBag._mode = m;
				}
			});

			return View();
		}

		[ValidateInput(false)]
		public ActionResult fullpage_editor()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.AllowScriptCode = true;
				editor.EditCompleteDocument = true;
				editor.TagBlackList = "";
				editor.Text = "<html><head></head><body><div>Editor full html page</div><br/><br/>" +
					"<div style='font-weight:bold;'>editor.AllowScriptCode = true;<br/>editor.EditCompleteDocument = true;<br/>editor.TagBlackList = \"\";</div></body></html>";

			});

			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult fullpage_editor(string m = "")
		{
			Editor theeditor = PrepairEditor(delegate(Editor editor)
			{
				editor.AllowScriptCode = true;
				editor.EditCompleteDocument = true;
				editor.TagBlackList = "";
			});

			ViewBag._content = theeditor.Text;
			return View();
		}

		[ValidateInput(false)]
		public ActionResult javascript_api()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.Width = Unit.Pixel(600);
				editor.Height = Unit.Pixel(300);
				editor.Skin = "smartgray";
				editor.Toolbar = "minimal";
			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult jquery_tabs()
		{
			Editor Editor1 = PrepairEditor(delegate(Editor editor)
			{
				editor.ID = editor.Name = "Editor1";
				editor.Width = Unit.Pixel(600);
				editor.Height = Unit.Pixel(300);
				editor.Skin = "office2003blue";
				editor.Toolbar = "email";
				editor.Text = "Tab # 1 content";
			});

			Editor Editor2 = PrepairEditor(delegate(Editor editor)
			{
				editor.ID = editor.Name = "Editor2";
				editor.Width = Unit.Pixel(600);
				editor.Height = Unit.Pixel(300);
				editor.Skin = "smartblue";
				editor.Toolbar = "email";
				editor.Text = "Tab # 2 content";
			});

			Editor Editor3 = PrepairEditor(delegate(Editor editor)
			{
				editor.ID = editor.Name = "Editor3";
				editor.Width = Unit.Pixel(600);
				editor.Height = Unit.Pixel(300);
				editor.Skin = "officexpsilver";
				editor.Toolbar = "email";
				editor.Text = "Tab # 3 content";
			});

			ViewBag.Editor1 = Editor1.MvcGetString();
			ViewBag.Editor2 = Editor2.MvcGetString();
			ViewBag.Editor3 = Editor3.MvcGetString();
			return View();
		}

		[ValidateInput(false)]
		public ActionResult localization()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult localization(string m = "")
		{
			PrepairEditor(delegate(Editor editor)
			{
				m = Request.Form["SelectType"];
				if (!string.IsNullOrEmpty(m))
				{
					editor.Language = m;
					ViewBag._mode = m;
				}
			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult maxlength()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult maxlength(string m = "")
		{
			PrepairEditor(delegate(Editor editor)
			{
				m = Request.Form["SelectType"];
				if (!string.IsNullOrEmpty(m))
				{
					if (m == "html")
					{
						editor.MaxHTMLLength = 100;
					}
					if (m == "text")
					{
						editor.MaxTextLength = 100;
					}
					ViewBag._mode = m;
				}
			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult mswordcleanup()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult multi_editor()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.Width = Unit.Pixel(500);
				editor.Height = Unit.Pixel(300);
				editor.Skin = "smartsilver";
				editor.Toolbar = "forum";
			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult multiple_editors()
		{
			Editor Editor1 = PrepairEditor(delegate(Editor editor)
			{
				editor.ID = editor.Name = "Editor1";
				editor.Width = Unit.Pixel(750);
				editor.Height = Unit.Pixel(300);
				editor.Skin = "smartblue";
				editor.Toolbar = "forum";
				editor.Text = "<div style='color:red;'><strong>1. Easy for developers</strong></div>";
			});

			Editor Editor2 = PrepairEditor(delegate(Editor editor)
			{
				editor.ID = editor.Name = "Editor2";
				editor.Width = Unit.Pixel(750);
				editor.Height = Unit.Pixel(300);
				editor.Skin = "smartsilver";
				editor.Toolbar = "forum";
				editor.Text = "<div style='color:darkgreen;'><strong>2. Seamless Integration with Web Forms</strong></div>";
			});
			
			ViewBag.Editor1 = Editor1.MvcGetString();
			ViewBag.Editor2 = Editor2.MvcGetString();

			if (Request.HttpMethod == "POST")
			{
				ViewBag._content = "<div style='font-size:16px;font-weight:bold;'>RichTextEditor 1:</div><br/>" + Editor1.Text
					+ "<br/><div style='font-size:16px;font-weight:bold;'>RichTextEditor 2:</div><br/>" + Editor2.Text;
			}
			return View();
		}

		[ValidateInput(false)]
		public ActionResult noneditable_contents()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult onpaste()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.PasteMode = RTEPasteMode.Default;
			});

			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult onpaste(string m = "")
		{
			PrepairEditor(delegate(Editor editor)
			{
				m = Request.Form["SelectType"];
				if (!string.IsNullOrEmpty(m))
				{
					if (m == "Disabled")
					{
						editor.PasteMode = RTEPasteMode.Disabled;
					}
					if (m == "Paste")
					{
						editor.PasteMode = RTEPasteMode.Paste;
					}
					if (m == "PasteText")
					{
						editor.PasteMode = RTEPasteMode.PasteText;
					}
					if (m == "PasteWord")
					{
						editor.PasteMode = RTEPasteMode.PasteWord;
					}
					if (m == "ConfirmWord")
					{
						editor.PasteMode = RTEPasteMode.ConfirmWord;
					}
					ViewBag._mode = m;
				}
				else
					editor.PasteMode = RTEPasteMode.Default;
			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult plaintext()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult plaintext(string m = "")
		{
			Editor theeditor = PrepairEditor(delegate(Editor editor)
			{

			});

			ViewBag._content = theeditor.PlainText;

			return View();
		}

		[ValidateInput(false)]
		public ActionResult readonly_editor()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.Text = "This is a readonly editor.";
				editor.ReadOnly = true;
			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult relative_absolute_urls()
		{
			PrepairEditor(delegate(Editor editor)
			{
				string _text = "<div>" +
					"<a href=\"some.htm\">This is a relative path</a><br />" +
					"<br />" +
					"<a href=\"/some.htm\">This is a Site Root Relative path</a>" +
					"<br />" +
					"<br />" +
					"<a href=\"http://somesite/some.htm\">This is a absolute path.</a><br />" +
					"<br />" +
					"<a href=\"#tips\">This is a link to anchor.</a><br />" +
				"</div>";
				editor.Text = _text;
			});

			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult relative_absolute_urls(string m = "")
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.Height = Unit.Pixel(420);
				string mode = Request.Form["SelectType"];

				if (!string.IsNullOrEmpty(mode))
				{
					ViewBag._mode = mode;
					if (mode == "abs")
					{
						editor.URLType = RTEURLType.Absolute;
					}
					else if (mode == "rel")
					{
						editor.URLType = RTEURLType.SiteRelative;
					}
					else
					{
						editor.URLType = RTEURLType.Default;
					}
				}
			});

			return View();
		}

		[ValidateInput(false)]
		public ActionResult security()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult security(string m = "")
		{
			PrepairEditor(delegate(Editor editor)
			{
				string selecttype = "";
				string _secstr = "";
				selecttype = Request.Form["SelectType"];
				ViewBag._selecttype = selecttype;
				string _store = "";
				RTE.ConfigFile file;
				RTE.ConfigSecurity[] storages;
				editor.RenderSupportAjax = false;
				switch (selecttype)
				{
					case "Administrators":
						editor.SecurityPolicyFile = "admin.config";
						_secstr = "Policy file:" + editor.SecurityPolicyFile + "<br/>";
						break;
					case "Members":
						editor.SecurityPolicyFile = "default.config";
						_secstr = "Policy file:" + editor.SecurityPolicyFile + "<br/>";
						break;
					case "Guest":
						editor.SecurityPolicyFile = "guest.config";
						_secstr = "Policy file:" + editor.SecurityPolicyFile + "<br/>";
						break;
					case "John":
						editor.SecurityPolicyFile = "admin.config";
						file = editor.LoadConfigFile();
						storages = file.GetItems("Gallery", false, true);
						_store = storages[0].StoragePath + "/John";
						editor.SetSecurity("Gallery", "*", "StoragePath", _store);
						_secstr = "Policy file:" + editor.SecurityPolicyFile + "<br/> Gallery:" + _store;
						break;
					case "Mary":
						editor.SecurityPolicyFile = "default.config";
						file = editor.LoadConfigFile();
						storages = file.GetItems("Gallery", false, true);
						_store = storages[0].StoragePath + "/Mary";
						editor.SetSecurity("Gallery", "*", "StoragePath", _store);
						_secstr = "Policy file:" + editor.SecurityPolicyFile + "<br/> Gallery:" + _store;
						break;
					case "Tim":
						editor.SecurityPolicyFile = "default.config";
						file = editor.LoadConfigFile();
						storages = file.GetItems("Gallery", false, true);
						_store = storages[0].StoragePath + "/Tim";
						editor.SetSecurity("Gallery", "*", "StoragePath", _store);
						_secstr = "Policy file:" + editor.SecurityPolicyFile + "<br/> Gallery:" + _store;
						break;
				}

			});

			return View();
		}

		[ValidateInput(false)]
		public ActionResult showrulers()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.ShowRulers = true;
			});

			return View();
		}

		[ValidateInput(false)]
		public ActionResult skinning_editor()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.Text = "Type here";
				string skin = Request.QueryString["skin"];
				if (Request.UserAgent.IndexOf("Mobile") >= 0)
					skin = "phonesilver";
				if (string.IsNullOrEmpty(skin))
					skin = "office2007blue";
				editor.Skin = skin;
				string toolbar = Request.QueryString["toolbar"];
				if (!string.IsNullOrEmpty(toolbar))
					editor.Toolbar = toolbar;
				string[] itemlist = new string[]{
					""
					,"{fullscreen,undo,redo,find}{insertlink,unlink}{insertlinemenu,justifymenu,insertorderedlist,insertunorderedlist,outdent,indent,insertblockquote}{inserttable,insertgallery,insertimage}{inserttemplate,insertdocument,insertmedia,insertyoutube,html5,googlemap}{help}/[paragraphs,styles][fontname,fontsize]{bold,italic,underlinemenu}{forecolor,backcolor}{superscript,subscript,changecase}{removeformat}{formatpainter}"
					,"{save,new,print,spellcheck}{paste,pastetext,pasteword}{cut,copy,delete,find}{undo,redo}{inserttable,insertgallery,insertimage}{inserttemplate,insertdocument,insertmedia,syntaxhighlighter,insertyoutube,html5,googlemap}/[fontname,fontsize]{bold,italic,underlinemenu}{forecolor,backcolor}{superscript,subscript,changecase}{removeformat,cleancode,selectall}{formatpainter}{insertlink,unlink,insertanchor,insertimagemap,insertdate,insertchars,virtualkeyboard}/[paragraphs,styles]{justifymenu,lineheight,ltr,rtl,insertlinemenu}{insertorderedlist,insertunorderedlist,outdent,indent,insertblockquote}{insertform,insertbox,insertlayer,insertfieldset,fullscreen,toggleborder,pageproperties,help}"
					,"<@COMMON,ribbonpaste,pastetext,pasteword,{save,new,print,spellcheck}{cut,copy,delete,find}{undo,redo|formatpainter}><@FORMAT,[fontname,fontsize]{bold,italic,underlinemenu|forecolor,backcolor}{superscript,subscript,changecase|removeformat,cleancode,selectall}><@PARAGRAPHS,[paragraphs,styles]{justifymenu,lineheight,ltr,rtl,insertlinemenu}{insertorderedlist,insertunorderedlist,outdent,indent,insertblockquote}><@INSERT,ribbontable,insertgallery,insertimage,{insertform,insertbox,insertlayer,insertfieldset,fullscreen,toggleborder,pageproperties,help}{insertlink,unlink,insertanchor,insertimagemap,insertdate,insertchars,virtualkeyboard}{inserttemplate,insertdocument,insertmedia,syntaxhighlighter,insertyoutube,html5,googlemap}>"
				};

				int index;
				if (int.TryParse(Request.QueryString["itemlist"], out index))
				{
					if (index >= 0 && index < itemlist.Length)
					{
						editor.ToolbarItems = itemlist[index];
					}
				}
			});

			return View();
		}

		[ValidateInput(false)]
		public ActionResult table_support()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult bbcode()
		{
			PrepairEditor(delegate(Editor editor)
			{
				ViewBag.BBCode = editor.BBCode;
			});
			return View();
		}

		[ValidateInput(false)]
		public ActionResult watermark()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.AjaxPostbackUrl = Url.Action("watermark");
                if(Request.HttpMethod=="POST")
                    editor.UploadImage += new UploadImageEventHandler(Editor1_UploadImage);
			});
			return View();
		}


        //[ValidateInput(false)]
        //public ActionResult watermark_handler()
        //{
        //    PrepairEditor(delegate(Editor editor)
        //    {
        //        editor.UploadImage += new UploadImageEventHandler(Editor1_UploadImage);
        //    });
        //    return new EmptyResult();
        //}

		void Editor1_UploadImage(object sender, UploadImageEventArgs args)
		{
			string text = Request["txt_watermark"];
			System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(400, 200, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
			{
				System.Drawing.FontStyle style = System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline;
				System.Drawing.Font font = new System.Drawing.Font(System.Drawing.FontFamily.GenericMonospace, 26, style);
				System.Drawing.SizeF size = g.MeasureString(text, font);
				g.DrawString(text, font, System.Drawing.Brushes.DarkGreen, bitmap.Width - size.Width, bitmap.Height - size.Height);
			}

			RTE.ConfigWatermark watermark = new ConfigWatermark();
			watermark.XAlign = "right";
			watermark.YAlign = "bottom";
			watermark.XOffset = -10;
			watermark.YOffset = -10;
			watermark.MinWidth = 450;
			watermark.MinHeight = 300;
			watermark.Image = bitmap;

			args.Watermarks.Clear();
			args.Watermarks.Add(watermark);
			args.DrawWatermarks = true;
		}


		[ValidateInput(false)]
		public ActionResult showlinkbar()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.Text = "<a href='http://cutesoft.net' target='_blank'>This is a test link</a>";
			});

			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult showlinkbar(string m = "")
		{
			PrepairEditor(delegate(Editor editor)
			{
				m = Request.Form["SelectType"];
				if (!string.IsNullOrEmpty(m))
				{
					if (m == "yes")
					{
						editor.ShowLinkbar = true;
					}
					if (m == "no")
					{
						editor.ShowLinkbar = false;
					}
					ViewBag._mode = m;
				}
				editor.Text = "<a href='http://cutesoft.net' target='_blank'>This is a test link</a>";
			});
			return View();
		}


		[ValidateInput(false)]
		public ActionResult format_bold()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.ToolbarItems = "{bold}";
				editor.Text = "Please select text and click bold button";
			});
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult format_bold(string m = "")
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.Text = "Please select text and click bold button";
				editor.ToolbarItems = "{bold}";
				m = Request.Form["SelectType"];
				if (!string.IsNullOrEmpty(m))
				{
					if (m == "b")
						editor.SetConfig("format_bold", "<b>");
					else if (m == "span")
						editor.SetConfig("format_bold", "<span style='font-weight:bold'>");
					ViewBag._mode = m;
				}
			});

			return View();
		}


		[ValidateInput(false)]
		public ActionResult capture_save()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}


		[ValidateInput(false)]
		public ActionResult populate_menu()
		{
			PrepairEditor(delegate(Editor editor)
			{
				//add content css
				editor.ContentCss = "/Content/dynamicstyles.css";
				//set font name, font size list by servercode
				//editor.SetConfig("fontnamelist", "Arial,Microsoft YaHei,Verdana");
				//editor.SetConfig("fontsizelist","9px,13px,16px,20px,24px,32px");

				editor.ToolbarItems = "{styles,fontname,fontsize}{mydropdownlink,mydropdowncodesnippet}";
			});
			return View();
		}


		[ValidateInput(false)]
		public ActionResult select_image()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}


		[ValidateInput(false)]
		public ActionResult select_file()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}


		[ValidateInput(false)]
		public ActionResult simple_editor()
		{
			Editor Editor1 = PrepairEditor(delegate(Editor editor)
			{
				editor.ID = editor.Name = "Editor1";
				editor.Height = Unit.Pixel(200);
				editor.Text = "Type here";
				editor.Skin = "officexpsilver";
				editor.Toolbar = "minimal";
			});

			Editor Editor2 = PrepairEditor(delegate(Editor editor)
			{
				editor.ID = editor.Name = "Editor2";
				editor.Height = Unit.Pixel(200);
				editor.Text = "Type here";
				editor.Skin = "officexpblue";
				editor.Toolbar = "email";
			});

			Editor Editor3 = PrepairEditor(delegate(Editor editor)
			{
				editor.ID = editor.Name = "Editor3";
				editor.Height = Unit.Pixel(200);
				editor.Text = "Type here";
				editor.Skin = "office2003silver2";
				editor.Toolbar = "forum";
			});

			Editor Editor4=PrepairEditor(delegate(Editor editor)
			{
				editor.ID = editor.Name = "Editor4";
				editor.Height = Unit.Pixel(200);
				editor.Text = "Type here";
				editor.Skin = "office2003blue";
				editor.Toolbar = "light";
			});

			ViewBag.Editor1 = Editor1.MvcGetString();
			ViewBag.Editor2 = Editor2.MvcGetString();
			ViewBag.Editor3 = Editor3.MvcGetString();
			ViewBag.Editor4 = Editor4.MvcGetString();

			return View();
		}


		[ValidateInput(false)]
		public ActionResult switch_editor()
		{
			PrepairEditor(delegate(Editor editor)
			{
				editor.Width = Unit.Pixel(750);
				editor.Height = Unit.Pixel(360);
			});
			return View();
		}


		[ValidateInput(false)]
		public ActionResult output_xhtml()
		{
			PrepairEditor(delegate(Editor editor)
			{

			});
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult output_xhtml(string m = "")
		{
			Editor theeditor=PrepairEditor(delegate(Editor editor)
			{

			});

			ViewBag._content = theeditor.XHTML;

			return View();
		}
	}
}
