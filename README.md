# jsonrpc-sample

## �M�׷��z
`jsonrpc-sample` �O�@�Ӱ�� JSON-RPC ���d�Ҥ�סA�i�ܦp��ϥ� .NET �޳N��{�Ȥ�ݻP���A���ݪ����ʡC����ץ]�t�H�U�D�n�\��G
- �Ȥ�ݪ�l�ƻP���A�����I�]�w�C
- �ϥ� JSON-RPC ��k�i��~���޿�ާ@�]�p `Ping` �M `Hello` ��k�^�C
- �䴩�t�μh�ŻP���h�Ū��~���޿誫��C

---

## �M�׬[�c
����ץ]�t�H�U�D�n�ҲաG
1. **JsonRpcClient**:
   - ���� Windows Forms ���ε{���A�i�ܦp��ϥ� JSON-RPC �P���A�����ʡC
   - �]�t���s�ƥ�B�z��k�A�p `btnInitialize_Click`�B`btnPing_Click` �M `btnHello_Click`�C

2. **JsonRpcServer**:
   - ���Ѧ��A���ݪ��X�R��k�P API �w�q�C
   - �ϥ� `BackendExtensions` �i����A����l�ơA�]�w `DefinePath` �M API �A�ȿﶵ�C

3. **Custom.Business**:
   - �w�q�~���޿誫��A�p `TEmployeeObject`�A�ù�{���骺�~���޿��k�]�p `Hello` ��k�^�C

4. **Custom.Define**:
   - �w�q�~���޿�ѼƻP���G�����A�Ҧp `THelloArgs` �M `THelloResult`�C

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