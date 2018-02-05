// forum2.cpp : Defines the entry point for the console application.
//

#include <iostream>


using namespace std;
int main()
{
	cout << "Hello," << endl;
	cout << "whats your name?" << endl;
	char ime[20];
	cin >> ime;
	cout << "Hello, " << ime << ". I said \"hello\"!\n";
	cout << "How old are you?";
	int i; cin >> i;
	cout << "\a\tI see that you, " << ime << " are ";
	cout << i << " years old." << endl;
}

