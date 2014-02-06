#include <iostream>
#include <string>
#include <limits>

using namespace std;

int main()
{
	int trackNumber = 0;
	
	do
	{
		cout << "Pls enter track number: ";
		cin >> noskipws >> trackNumber;

		if (cin.fail())
		{
			cout << "What a load of rubbish\n";
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			trackNumber = 0;
			continue;
		}

		cout << "You entered: " << trackNumber << endl;
		cin.ignore();
	} while (trackNumber < 1 || trackNumber > 4);

	return 0;
}
