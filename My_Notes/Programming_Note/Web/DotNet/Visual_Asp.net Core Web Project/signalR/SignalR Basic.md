�D�n�ѦҷL�n�о�
https://docs.microsoft.com/zh-tw/aspnet/core/tutorials/signalr?view=aspnetcore-3.1&tabs=visual-studio

���A�ԭz�U�z�Ѫ����e

1. �����bVS asp.net core web project�W���w�ˤ覡
   	�b [����`��]���A�H�ƹ��k����@�U�M�סA�M���� [�s�W][�Τ�ݵ{���w]�C
   	�b [�s�W�Τ�ݵ{���w]��ܤ�����A�w�� [���Ѫ�]��� [unpkg]�C
   	�w�� [�{���w]��J @microsoft/signalr@latest�C
   	��� [��ܯS�w�ɮ�]�B�i�} [dist/browser]��Ƨ��A�M���� signalr.js �P signalr.min.js�C
   	�N�ؼЦ�m�]�w��wwwroot/js/�H����/, �M���� �u�w�ˡv �C
   	

	PS.�n���u���Ψ�signalr.js �t�@�Ӥ��T�w���S����
2. �b�M�ש��U(�����N���|)(�ӤH�u�Χ��Ī��ߺD./Services/)(�L�n�d�ҬO./Hubs/)�إ�cs����
   `using Microsoft.AspNetCore.SignalR`�H��`System.Threading.Tasks`��b�̭��إߤ@��class�~��`Microsoft.AspNetCore.SignalR.Hub`�æb�䤤�إߤ@��public async Task
   	�H�U���L�n�d��

```C#


using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
	{
      public async Task SendMessage(string user, string message)
       {
          await Clients.All.SendAsync("ReceiveMessage", user, message);
       }
	}
}
```

3. ���ۦbstartup.cs��using�W�@�B�Jcs��namespace

   �bConfigureServices���[�Jservices.AddSignalR();

   �bapp.UseEndpoints(endpoints =>���[�Jendpoints.MapHub<ChatHub(�ĤG�B�~��Hub��Class)>("/hub class�W�� ���Ϥ��j�p�g");

4. html �ޥΪ����e

```html
<script src="�Ĥ@�B�w�˪�signalr.js���|"></script>
```

?	�|�F�o�q�|���jquery�ҥ~ Promise ���g�w�q�C

5. js/ts�ɮת����e(�L�n�d�ҬOjs�A���߱o�H�������x��ts���D)
   �Hts���g���ܭn`import * as signalR from "@microsoft/signalr"`
   �H�U���e����b`$(document).ready(function(){})`�̭�

   ```typescript
   var connection:signalR.HubConnection = new signalR.HubConnectionBuilder().withUrl("/hub class�W�� ���Ϥ��j�p�g").build();
   connection.on("TaskĲ�o���ƥ�W��"function(){�Q������})
   connection.start().then(function () {�s�u���\��Q������});
   //Ĳ�oTask���覡
   connection.invoke("Task�W��",�᭱��Ѽ�)
   ```

   


6.�ɥR �H�U�ޥΦ� https://ithelp.ithome.com.tw/articles/10203113

�s���ƥ�

```C#
var connection = new signalR.HubConnectionBuilder().withUrl("/Hub�W��").build();
```

�}�l�s��

```C#
connection.start()
.then(function(){
    // �s�����\��n�����Ʊ�
})
.catch(function(err){
    // ���~�B�z
});
```



�����s��

```C#
connection.stop().catch(function(err){
    // ���~�B�z
});
```



��ť�s����������

```C#
connection.onclose(function(e){
    // �����ɷQ������
});
```

