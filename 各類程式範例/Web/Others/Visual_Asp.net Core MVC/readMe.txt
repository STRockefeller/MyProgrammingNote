�P�DMVC�M��
��ĳ
1.�M�׫إ߮ɧ�SSL�{�Ҩ����Ŀ�
2.Debug��ܱM�צW�٦ӫDIIS
3.��wwwroot�ڥؿ����u�O�d�@��html�ɮץB��startup Configure��k���[�J  app.UseDefaultFiles();�N�i�H�����ɦV�ӭ����ӫD�w�]�e���C

------------------------------------------------------------------------------------------------------------------------------------

MVC only
1.�[�J MVC ���A��(REF https://blog.yowko.com/aspdotnet-core-addmvc-addmvccore/)
	Startup.ConfigureServices���[�Jservices.AddMvc();�Ϊ� AddMvcCore();

2.�]�wMVC���� �H�U��Ӥ�k�ܤ@
2.1.�b Configure �� IApplicationBuilder �ϥ� UseMvcWithDefaultRoute ��k���U MVC �w�]���Ѫ� Middleware 

public void Configure(IApplicationBuilder app)
    {
        app.UseMvcWithDefaultRoute();
    }
2.2.�Ϊ̨ϥιw�]Startup.cs �̫�誺���� Controller �M Action ���V�̪���檺���e
 app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=About}/{id?}");
            });


4.����Controller:
4.1.�����~��Controller�~��ϥ�View
4.2.�H�U�`���� https://ithelp.ithome.com.tw/articles/10193590
IActionResult �^�Ǫ��覡�i�H���ܦh�ءA�z�L�~�� Controller ��A�N�i�H�ϥ� Controller ����k�G

View
�H�W�Ҩӻ��A�z�L�^�� View ��k�A�i�H���� Controller & Action ������ *.cshtml�A �åB�� UserModel �ǵ� View �ϥΡC
HTTP Status Code
�^���]�t HTTP Status�C�`�Ϊ��^���� Ok�BBadRequest�BNotFound ���C
�Ҧp�Greturn BadRequest("Internal Server Error")�A�|�^�� HTTP Status 400 �� Internal Server Error �r��C
Redirect
�i�H�� Request �൹��L�� Action �� URL�C��V����k�� Redirect�BLocalRedirect�BRedirectToAction�BRedirectToRoute ���C
�Ҧp�Greturn RedirectToAction("Login", "Authentication")�A�N�|�� Request ��V�� AuthenticationController �� Login()�C
Formatted Response
�^���ɫ��w Content-Type�CWeb API ���^�ǳq�`���γo�ؤ覡�A�ǦC�ƪ��󶶫K�е� Content-Type�C
�Ҧp�Greturn Json(user)�A�|�N����ǦC�Ʀ� JSON �r��A�æb HTTP Headers �a�W Content-Type=application/json�C


5.����VIEW
View �� Controller ���ۤ����������Y�A�w�]�b Controller �ϥ� View ��k�^�ǵ��G�A�|�q�H�U�ؿ��M������� *.cshtml�G

Views\{ControllerName}\{ActionName}.cshtml
�M��P Controller �P�W���l�ؿ��A�A���P Action �P�W�� *.cshtml�C
�p�W�� HomeController.Index()�A�N�|��M�ץؿ��U�� Views\Home\Index.cshtml �ɮסC
Views\Shared\{ActionName}.cshtml
�p�G Controller �P�W���l�ؿ��A�䤣�� Action �P�W�� *.cshtml�C�N�|�� Shared �ؿ���C
�p�W�� HomeController.Index()�A�N�|��M�ץؿ��U�� Views\Shared\Index.cshtml �ɮסC