REF
1.MSDN https://docs.microsoft.com/zh-tw/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.1
2.ithelp
https://ithelp.ithome.com.tw/articles/10203041
https://ithelp.ithome.com.tw/articles/10192682


1.App.Use
��|�ϥ�Use�i��ۭq��Middleware�X�R�A��z�L�I�snext()���w����U�@�hMiddleware(�i�[�J����P�_�M�w�O�_�I�s)�A�]�i���w�b�޽u�^�y�ɩҭn���檺�欰�C
Middleware �����U�覡�O�b Startup.cs �� Configure �� IApplicationBuilder �ϥ� Use ��k���U�C
�j�����X�R�� Middleware �]���O�H Use �}�Y����k���U�A�Ҧp�G

UseMvc() �GMVC �� Middleware
UseRewriter() �GURL rewriting �� Middleware

2.App.Run
Run �O Middleware ���̫�@�Ӧ欰�A�H�W���ϨҨӻ��A�N�O�̥��ݪ� Action�C
������ Use ����p��L Middleware�A�� Run �٬O�৹�㪺�ϥ� Request �� Response�C

3.App.Map
Map �O��ΨӳB�z�@��²����Ѫ� Middleware�A�i�̷Ӥ��P�� URL ���V���P�� Run �ε��U���P�� Use�C
�D�n�b�P�_���ѳW�h�O�_�ŦX�w���A�ŦX�h����϶����e�C