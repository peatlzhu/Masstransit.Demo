::------------------------------------------------
:: ��       �ߣ���  �� 
:: ����ʱ�� ��2019/5/25 10:31:01
:: My Email ��jiangyan2008.521@gmail.com 
::                   jiangyan2008.521@qq.com  
::
:: ����˵�� ��ִ�и��ļ����Կ���������Ŀ��Դ����״̬
:: �޸���ʷ �� 
:: 
:: <returns>�ɾ�����</returns>
::=================================================

::-------------------------------------------------
:: * Initialize *
del /s /ah /f *.suo
del /s /f *.user
del /s /f *.cache
del /s /f *.keep
del /s /ah StyleCop.Cache

rd /s /q bin obj packages 

del dirs.txt
dir /s /b /ad bin > dirs.txt
dir /s /b /ad obj >> dirs.txt
dir /s /b /ad packages >> dirs.txt

for /f "delims=;" %%i in (dirs.txt) DO rd /s /q "%%i"
del dirs.txt
