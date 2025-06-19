# jsonrpc-sample

## �M�׷��z
`jsonrpc-sample` �O�@�Ӱ�� JSON-RPC ���d�Ҥ�סA�i�ܦp��ϥ� .NET �޳N��{�Τ�ݻP���A���ݪ����ʡC����ץ]�t�H�U�D�n�\��G
- JSON-RPC ���A�ݪ�l�ơC
- JSON-RPC �Τ�ݨϥλ��ݳs�u�A�Ω��ڹB�����ҡC
- JSON-RPC �Τ�ݨϥΪ�ݳs�u�A�Ω�}�o���q�����C
- �ϥ� JSON-RPC ��k�i��~���޿�ާ@�]�p `Ping` �M `Hello` ��k�^�C
- �䴩�t�μh�ŻP���h�Ū��~���޿誫��C
- JSON-RPC �ǻ���ƶi��s�X�]�ǦC�� + ���Y + �[�K�^�C

---

## �M�׬[�c
����ץ]�t�H�U�D�n�ҲաG
1. **DefinePath**:
   - �w�q��Ʀs����|�A�p `System.Settings.xml`�B`Database.Settings.xml` ���C
   - ���d�ҥu�|�ϥΨ� `System.Settings.xml`�C

2. **Custom.Define**:
   - �w�q�~���޿�ѼƻP���G�����A�Ҧp `THelloArgs` �M `THelloResult`�C
   - �~���޿�ѼƻP���G���O�C
   - JSON-RPC ���Τ�ݤΦ��A���ݬһݤޥΦ��ե�C

3. **Custom.Business**:
   - �w�q�~���޿誫��A�p `TEmployeeBusinessObject`�A�ù�{���骺�~���޿��k�]�p `Hello` ��k�^�C
   - JSON-RPC ���A�ݪ����n�ե�C
   - JSON-RPC �Τ�ݦb�}�o���q�ϥΪ�ݳs�u�ɡA�ݤޥΦ��ե�C
   - �䴩 JSON-RPC �I�s���~���޿��k�A�ǤJ�ѼƤζǥX���G�Ҭ����O�A�Ҧp `Hello` ���ǤJ�ѼƬ� `THelloArgs`�A�ǥX���G�� `THelloResult`�C

4. **JsonRpcServer**:
   - ���Ѧ��A���ݪ��X�R��k�P API �w�q�C
   - �ϥ� `BackendExtensions` �i����A����l�ơA�]�w `DefinePath` �M API �A�ȿﶵ�C

5. **JsonRpcClient**:
   - ���� Windows Forms ���ε{���A�i�ܦp��ϥ� JSON-RPC �P���A�����ʡC
   - �ϥ� `Bee.Connect` �M�� Connector ���� JSON-RPC ��k�C
   - �ϥ� `Bee.UI.WinForms` �M�� ClientInfo �إ� Connector ���� JSON-RPC ��k�C

---

## JSON-RPC �ШD�d��
`method` ���榡�� `{ProgID}.{Method}`�C
`"$type"` �� Method �ǤJ�Ѽƫ��O�C
{
  "jsonrpc": "2.0",
  "method": "Employee.Hello",
  "params": {
    "value": {
      "$type": "Custom.Define.THelloArgs, Custom.Define",
      "userName": "Jeff"
    }
  },
  "id": "e942952b-6450-412c-bb24-c6ab7c804789"
}
---

## �}�o�̫��n
1. **�]�m System.Settings.xml**:
   - �]�w `AllowedTypeNamespaces` �� JSON �ϧǦC�ƪ��R�W�Ŷ��զW��C
   - �]�w `ApiPayloadOptions` ���s�X�覡�]�ǦC�� + ���Y + �[�K�^�C
   - ���w `BusinessObjectProvider` ���~���޿誫�󴣨Ѫ̡C

2. **�X�i�~���޿�**:
   - �b `Custom.Business` �M�פ��s�W�~���޿誫��A�ù�{������k�C
   - �b `Custom.Define` �M�פ��w�q�~���޿��k���ǤJ�ѼƤζǥX���G���O�C

3. **�Ұʦ��A��**:
   - �Ұ� `JsonRpcServer` �M�סA�ϥ� `BackendExtensions.BackendInitialize` ��k�i����A����l�ơG
     - �]�w `DefinePath`�A�T�O�ؿ��s�b�C
     - ��l�ƨt�γ]�w�P API �A�ȿﶵ�C
   - �ϥ� `jsonrpc.http` ������ JSON-RPC ��k�A�T�{���A�ݥ��`�B��C

4. **�ҰʫȤ��**:
   - �Ұ� `JsonRpcClient` �M�סA�ϥλ��ݩΪ�ݳs�u���� JSON-RPC ��k�C

---

## �t�λݨD
- **.NET 8**: �Ω�Ȥ�����ε{���C
- **.NET Standard 2.0**: �Ω�~���޿�ҲաC

---

## �p���覡
�p��������D�A���p���}�o�̹ζ��C