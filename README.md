# jsonrpc-sample

## �M�׷��z
`jsonrpc-sample` �O�@�Ӱ�� JSON-RPC ���d�Ҥ�סA�i�ܦp��ϥ� .NET �޳N��{�Τ�ݻP���A���ݪ����ʡC����ץ]�t�H�U�D�n�\��G
- �Ȥ�ݪ�l�ƻP���A�����I�]�w�C
- �ϥ� JSON-RPC ��k�i��~���޿�ާ@�]�p `Ping` �M `Hello` ��k�^�C
- �䴩�t�μh�ŻP���h�Ū��~���޿誫��C

---

## �M�׬[�c
����ץ]�t�H�U�D�n�ҲաG
1. **DefinePath**:
   - �w�q��Ʀs����|�A�p Sysetm.Settings.xml�BDatabase.Settings.xml ���C
   - ���d�ҥu�|�ϥΨ� Sysetem.Settings.xml�C
	
2. **Custom.Define**:
   - �w�q�~���޿�ѼƻP���G�����A�Ҧp `THelloArgs` �M `THelloResult`�C
	- �~���޿�ѼƻP���G���O�A
	- JSON-RPC ���Τ�ݤΦ��A�ݬһݤޥΦ��ե�C
	
3. **Custom.Business**:
   - �w�q�~���޿誫��A�p `TEmployeeBusinessObject`�A�ù�{���骺�~���޿��k�]�p `Hello` ��k�^�C
	- JSON-RPC ���A�ݪ����n�ե�C
	-  JSON-RPC �Τ�ݦb�}�o���q�ϥΪ�ݳs�u�ɡA�ݤޥΦ��ե�C
   - �䴩 JSON-RPC �I�s���~���޿��k�A�ǤJ�ѼƤζǥX���G�Ҭ����O�A�Ҧp Hello ���ǤJ�ѱЬ� THelloArgs�A�ǥX���G�� THelloResult�C

4. **JsonRpcServer**:
   - ���Ѧ��A���ݪ��X�R��k�P API �w�q�C
   - �ϥ� `BackendExtensions` �i����A����l�ơA�]�w `DefinePath` �M API �A�ȿﶵ�C

3. **JsonRpcClient**:
   - ���� Windows Forms ���ε{���A�i�ܦp��ϥ� JSON-RPC �P���A�����ʡC
   - �ϥ� Bee.Connect �M�� Connector ���� JSON-RPC ��k�C
	- �ϥ� Bee.Connect �M�� ClientInfo �إ� Connector ���� JSON-RPC ��k�C

---

## �ϥΤ覡

### 1. �Ȥ�ݾާ@
#### ��l��
�b�Ȥ�����ε{�����A�I���u��l�ơv���s����H�U�ާ@�G
- ��l�ƫȤ�ݡA�ó]�w�䴩���s�u�����C
- �p�G�O���a�s�u�A�h���J�t�γ]�w�C

#### Ping ��k
�I���uPing�v���s������A���ݪ� `Ping` ��k�A���զ��A���O�_���`�B�@�C

#### Hello ��k
�I���uHello�v���s������A���ݪ� `Hello` ��k�A����ܪ�^���T���C

---

### 2. ���A���ݾާ@
#### ��l��
�ϥ� `BackendExtensions.BackendInitialize` ��k�i����A����l�ơG
- �]�w `DefinePath`�A�T�O�ؿ��s�b�C
- ��l�ƨt�γ]�w�P API �A�ȿﶵ�C

#### JSON-RPC ��k
���A���ݤ䴩�H�U JSON-RPC ��k�G
- **Ping**: ���զ��A���O�_���`�B�@�C
- **Hello**: ��^���Τ�W�٪��w��T���C

---

## JSON-RPC �d��
�H�U�O JSON-RPC �� HTTP �ШD�d�ҡG

### Ping ��k

---

## �t�λݨD
- **.NET 8**: �Ω�Ȥ�����ε{���C
- **.NET Standard 2.0**: �Ω�~���޿�ҲաC

---

## �}�o�̫��n
1. **�]�w DefinePath**:
   - �b���A���ݪ� `appsettings.json` ���]�w `DefinePath`�A���V�~���޿�w�q���ؿ��C

2. **�X�i�~���޿�**:
   - �b `Custom.Business` ���s�W�~���޿誫��A�ù�{������k�C

3. **���� JSON-RPC**:
   - �ϥ� `jsonrpc.http` �����զ��A���ݪ� JSON-RPC ��k�C

---

## �p���覡
�p��������D�A���p���}�o�̹ζ��C