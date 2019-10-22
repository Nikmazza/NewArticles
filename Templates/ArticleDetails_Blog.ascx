<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ArticleDetailsTemplateBase.ascx.vb" Inherits="EfficionConsulting.Articles.ArticleDetailsTemplateBase" %>
<div id="fb-root"></div>
<link href="/DesktopModules/DDRMenu/TreeViewBlog/jquery.treeview.css" type="text/css" rel="stylesheet"/>
<script type="text/javascript" src="/js/highslide.js"></script>
<script type="text/javascript" src="/js/highslide.config.js" charset="utf-8"></script>
<link rel="stylesheet" type="text/css" href="/js/highslide.css">
<!-- COMPARTIR -->
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.9/css/all.css" integrity="sha384-5SOiIsAziJl6AWe0HWRKTXlfcSHKmYV4RBF18PPJ173Kzn7jzMyFuTtk8JA7QQG1" crossorigin="anonymous">
<link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
<link rel="stylesheet" href="/DesktopModules/Proximitas/BuscadorCompleto/css/buscadorcompleto.css" >
<div class="modal_bk" style="display:none;">
</div>

<div class="modal_email" style="display:none;">
    <div class="row">
        <div class="col-xs-2 col-xs-offset-10 text-right">
            <i class="fas fa-window-close"></i>
        </div>
     </div>
    <h2>Env&iacute;o de documento</h2>
    <p >Ingrese el/los mail/s de los destinatatarios de los siguientes documentos:</p>
    <input type="hidden" id="id_doc"/>
    <input type="hidden" id="tipo_doc"/>
	<input type="hidden" id="tipo_envio"/>
    <label id="nombre" class="marginTop5"></label>
    <div class="row">
        <div class="col-xs-12 text-center">
            <select id="email_doc" multiple="multiple" style="width:100%;height:30px;"> </select> 
        </div>
        <div class="col-xs-12 text-center">
        <span class="btn btn-primary marginTop10" style="cursor:pointer;"> Enviar &nbsp;&nbsp;<em class="fa fa-envelope" aria-hidden="true"></em></span>
        <span class="btn btn-secondary marginTop10" style="display: none;"> Procesando &nbsp;&nbsp;<em class="fa fa-spinner" aria-hidden="true"></em></span>
		</div>
    </div>
</div>

<script>
	function validateEmail(email) {
	        var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
	        return re.test(email);
	    }
	$(document).ready(function(){
		$("#email_doc").select2({
			tags: true,
			tokenSeparators: [',', ';', ' '],
			placeholder: 'Separe cada uno distinto con Enter o coma',
			selectOnClose: true,
			createTag: function (term, data) {
				var value = term.term;
				if (validateEmail(value)) {
					return {
						id: value,
						text: value
					};
				}
				return null;
			}
			}
		);
	
	});
	function compartir_articulo()
	{
		$(".modal_bk").fadeIn(300);
		$(".modal_email").delay(200).fadeIn(500);
		$(".modal_email #tipo_envio").val("1");
		$(".modal_email #id_doc").val('<%= ArticleID%>');
		$(".modal_email #tipo_doc").val("art");
		$(".modal_email #nombre").text(document.title);
	}

	$(".modal_email .fa-window-close").click(function () {
		$(".modal_bk").fadeOut(300);
		$(".modal_email").fadeOut(300);
	});

	$(".modal_email .btn-primary").click(function () {
		$(".modal_email .btn-primary").hide();
		$(".modal_email .btn-secondary").show();
		setTimeout(function(){
		if($(".modal_email #tipo_envio").val() == "1" || ($(".modal_email #tipo_envio").val() == "2" && items_selects.length > 0))
		{
			
			var cont_envios = 0;
			for(e in $(".modal_email #email_doc").val())
			{
				try{
					var dest = $(".modal_email #email_doc").val()[e];
					$.ajax({
						type: "POST",
						async: false,
						url: "/DesktopModules/Proximitas/BuscadorCompleto/sendEmail.aspx",
						data: { userid: <%=UserID%> , tipo: $(".modal_email #tipo_doc").val(),id: $(".modal_email #id_doc").val(),email:dest,tipo_envio: $(".modal_email #tipo_envio").val() },
						beforeSend: function () {
						   $(".btn-primary").hide();
						},
						success:  function (response) { 
							
							 $(".modal_email #nombre span").css("color","green");
							 cont_envios = eval(cont_envios	+1);
							
							 if(cont_envios == $(".modal_email #email_doc").val().length)
							 {
								$(".modal_email .btn-primary").show();
								$(".modal_email .btn-secondary").hide();
								$(".modal_bk").fadeOut(300);
								$(".modal_email").fadeOut(300);	
								
								if($(".modal_email #tipo_envio").val() == "2")
								{
									
									while(items_selects.length > 0) {
										items_selects.pop();
									}
									if (Cookies.enabled) {Cookies.set('Biblioteca', items_selects, { expires: 3600 });}
									$(".resultado input[type='checkbox']").removeAttr('checked');
									$("#selDocs").html("(0)");
									
								}
							 }
						}
					});
				}
				catch(ex)
				{
				/**/
				}
				
			}				
			
	   }
	   else
	   {
			alert("Debe seleccionar archivos para compartir.");
	   }},1500);

	});

</script>

<!-- FIN COMPARTIR -->
<script>
  window.fbAsyncInit = function() {
    FB.init({
      appId      : 'xxxxxx',
      xfbml      : true,
      version    : 'v2.8'
    });
  };

  (function(d, s, id){
     var js, fjs = d.getElementsByTagName(s)[0];
     if (d.getElementById(id)) {return;}
     js = d.createElement(s); js.id = id;
     js.src = "//connect.facebook.net/en_US/sdk.js";
     fjs.parentNode.insertBefore(js, fjs);
   }(document, 'script', 'facebook-jssdk'));
</script>

<article id="container_articulo" class="articleConexion" runat="server">
    <div class="row"> 
        <div class="col-xs-7 col-md-8 marginTop10">
            <span class="sobretitulo" id="Categoria2" runat="server">
				<asp:Label CssClass="sobretituloText" ID="lblCategoria2" runat="server" />
			</span> 
        </div>  
		<div class="col-xs-5 col-md-4 marginTop20 text-right">
			<div class="row" id="shared" runat="server" Visible='<%#Request.isAuthenticated()%>'>
				<div class="col-xs-8 col-xs-offset-2 col-md-4 col-md-offset-7">
					<div class="btn-formulario" onclick="compartir_articulo();" style="cursor: pointer;">
						<a href="javascript:void(0);">Compartir <em class="fa fa-envelope" aria-hidden="true"></em> </a>
					</div>
				</div>
			</div>
			<div class="addthis_toolbox row" id="addthis" runat="server" Visible="False">
				<div class="col-xs-8 col-xs-offset-2 col-md-4 col-md-offset-7">
					<div class="row">
						<div class="col-xs-4">
							<!--<a class="addthis_button_email hidden-xs" addthis:url="[URL]"><img alt="email" src="/portals/0/Images/Commons/email.png" /></a>-->
						</div>
						<div class="col-xs-4">
							<!--<a class="addthis_button_twitter" addthis:url="[URL]"><img alt="twitter" src="/portals/0/Images/Commons/twitter.png" /></a>-->
						</div>
						<div class="col-xs-4">
							<!--<a class="addthis_button_facebook" addthis:url="[URL]"><img alt="facebook" src="/portals/0/Images/Commons/facebook.png" /></a>-->
							<a class="addthis_button_whatsapp visible-xs" addthis:url="[URL]"><img alt="whatsapp" src="/portals/0/Images/Commons/whatsapp.png" /></a>
						</div>
					</div>
				</div>
			</div>
		</div>
        <div class="col-xs-12 titulo">
			<div><a id="lnkEdit" runat="server"><img src="/images/edit.gif" alt="edit"></a></div>
            <h2><asp:Label ID="lblSubHead" runat="server" /></h2>
            <h1><asp:Label ID="lblTitle" runat="server" /></h1>
        </div>
    </div>
    <div class="row">
		<div class="col-xs-12 col-md-8 contenido-articulo-lateral">
            <div class="row">
                <div class="col-xs-12 col-md-12 foto" id="area_imagen" runat="server">
                    <asp:Image ID="imgArticleImage" CssClass="Thumbnail imagen" runat="server" AlternateText="Image text" />
					<div class="fotoCopete" id="fotoCopete" runat="server"><asp:Label ID="lblImageTitle" runat="server" /></div>
				</div>
				
                <div class="col-xs-12 col-md-12 abstract"  id="area_copete" runat="server">
                    <asp:Literal ID="litDescription" runat="server" />
                </div>
				<div class="col-xs-12 contenido">
					<asp:Literal ID="litArticle" Visible="<%# Authorized %>" runat="server" />
				</div>
            </div>
        </div>
		<div class="col-xs-12 col-md-4 barra-lateral">	
			
			<div class="row" id="area_mas_recientes" runat="server" Visible="<%# Request.IsAuthenticated %>">
				<div class="col-xs-12">
					<h5 class="masRelacionados art-recientes">ARTÍCULOS RECIENTES</h5>
				</div>
				<div class="col-xs-12" id="masNuevos" runat="server">
					
				</div>
			</div>
			<div class="row" id="area_mas_vistos" runat="server" Visible="<%# Request.IsAuthenticated %>">
				<div class="col-xs-12">
					<h5 class="masRelacionados art-mas-vistos">ARTÍCULOS MÁS VISTOS</h5>
				</div>
				<div class="col-xs-12" id="masVistos" runat="server">
					
				</div>
			</div>
			<div class="row articleConexion" id="area_categorias" runat="server" Visible="<%# Request.IsAuthenticated %>">
			  <div class="col-xs-12">
				<h5 class="masRelacionados">ARTÍCULOS POR CATEGORÍAS</h5>
			  </div>
			  <div class="col-xs-12">
				<ul class="treeview filetree">
				  <li><a href="/profesionales/articulos-medicos/lanzamientos">Lanzamientos</a></li>
				  <li><a href="/profesionales/articulos-medicos/noticias-medicas">Noticias médicas</a></li>
				  <li><a href="/profesionales/articulos-medicos/guias">Guías</a></li>
				  <li><a href="/profesionales/articulos-medicos/entrevistas">Entrevistas</a></li>
				  <li><a href="/profesionales/articulos-medicos/eventos">Eventos</a></li>
				  <li><a href="/profesionales/articulos-medicos/en-tema">En tema</a></li>
				  <li><a href="/profesionales/articulos-medicos/en-servicio">En servicio</a></li>
				  <li><a href="/profesionales/articulos-medicos/reflexiones">Reflexiones</a></li>
				  <li><a href="/profesionales/articulos-medicos/salud-y-belleza">Salud y Belleza</a></li>
				  <li><a href="/profesionales/articulos-medicos/gente-en-accion">Gente en acción</a></li>
				  
				</ul>
			  </div>
			</div>

        </div>
    </div>
</article>

    <div class="detailsStats" runat="server" visible="false">
        Categories: <%#GetCategoryList()%> |
		Author:
        <asp:HyperLink ID="hypUser" runat="server" />
        | 
		Posted:
        <asp:Literal ID="litDatePosted" runat="server" />
        |
		Views:
        <asp:Literal ID="litViews" runat="server" /><br />
    </div>
		<asp:Label id="lblNroRevista" runat="server" Visible="False"/>
    <asp:LinkButton ID="btnAnteriorSup" runat="server" Text="semana anterior" CssClass="articleSemanaNav prev"></asp:LinkButton>
    <asp:LinkButton ID="btnSiguienteSup" runat="server" Text="semana siguiente" CssClass="articleSemanaNav next"></asp:LinkButton>
    <asp:LinkButton ID="btnAnteriorInf" runat="server" Text="semana anterior" CssClass="articleSemanaNav prev"></asp:LinkButton>
    <asp:LinkButton ID="btnSiguienteInf" runat="server" Text="semana siguiente" CssClass="articleSemanaNav next"></asp:LinkButton>
	<div class="col-xs-12" id="masRelacionados" visible="False" runat="server"></div>    
    <asp:Label ID="lblUnauthorized" Text='<%# DotNetNuke.Services.Localization.Localization.GetString("NotAuthorized.Text", LocalResourceFile)%>' Visible="<%# not Authorized %>" runat="server" CssClass="normal" />
    <asp:Panel ID="pnlDetailButtonRow" CssClass="detailButtonRow" runat="server">
        <asp:HyperLink ID="lnkPrint" CssClass="CommandButton" runat="server" rel="NoFollow" Style="cursor: pointer;">
            <asp:Image ID="imgPrint" ImageUrl="~/DesktopModules/Articles/Print.gif" AlternateText='<%# DotNetNuke.Services.Localization.Localization.GetString("imgPrint.AlternateText", LocalResourceFile)%>' runat="server" />
        </asp:HyperLink>
        <asp:ImageButton ID="btnSendToFriend" AlternateText='<%# DotNetNuke.Services.Localization.Localization.GetString("SendToAFriend.Text", LocalResourceFile)%>' ImageUrl="~/DesktopModules/Articles/SendToAFriend.gif" runat="server" CssClass="CommandButton" />

        <asp:LinkButton ID="cmdReturn" runat="server" CssClass="CommandButton" Text='Volver' BorderStyle="none" Visible="false" CausesValidation="False" />
    </asp:Panel>

<asp:PlaceHolder  id="phComments" runat="server" />
