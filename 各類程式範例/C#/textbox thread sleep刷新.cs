//�����[�WtbxLog.Refresh()�~�i�H�b�C�Ӱj�鳣�N�T����ܦbtbxLog���A�_�h�D�����(Form)�|�����j��]���A�@����ܡC
        private void btnCt1NT_Click(object sender, EventArgs e)
        {

            int i = 0;
            while(i<20)
            {
                tbxLog.Text += $"\r\nNThread1{i.ToString()}";
                i++;
                Thread.Sleep(1000);
                tbxLog.Refresh();
            }
        }