//����#include <vector> using namespace std;

#include <iostream>
#include <vector>

using namespace std;

int main()
{
	vector<string> vStr;
	//�[�J����
	vStr.emplace_back("LaDiDa");
	vStr.emplace_back("Rockefeller");
	vStr.emplace_back("DamDaDiDoo");

	//�R���̫�@����
	//vStr.pop_back();

	//���R
	//vStr.~vector();
	//vStr.clear();

	//C++�� foreach
	for (auto& vstr : vStr)
	{
		cout << vstr << endl;
	}

	auto slice = vector<string>(vStr.begin(), vStr.begin() + 1);

	//size() ���ؼ� max_size() �O����e��
	cout << "Size:" << vStr.size() << endl << "Max Size:" << vStr.max_size() << endl;

	//�O�_���� �^��bool
	cout << vStr.empty() << endl;
	return 0;
}