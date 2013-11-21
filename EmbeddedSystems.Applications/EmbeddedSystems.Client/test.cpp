#include <iostream>
#include <string>
#include <limits>

using namespace std;

int main()
{
	string userInput;
	int trackNumber = 0;
	
	do
	{
		cout << "Pls enter track number: ";
		//getline (cin, userInput);
		cin >> trackNumber;
		if (cin.fail())
		{
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
