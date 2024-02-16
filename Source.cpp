#include <iostream>
#include <time.h>
#include <stdlib.h>
#include <math.h>
using namespace std;

int main()
{
  srand(time(0));
  double lambda;
  int count;

  cout << "Vvedite lambda ";
  cin >> lambda;
  cout << endl;

  cout << "Vvedite chislo opitov ";
  cin >> count;
  cout << endl;

  double x = 0;
  double y = 0;
  
  /*
  double max = 0;
  for (int c = 0; c < 1000; ++c)
  {
    x = ((double)rand()) / RAND_MAX;
    if (x < 0.5)
    {
      y = (log(2 * x)) / (lambda);
    }
    else if (x > 0.5)
    {
      y = -((log(2 - (2 * x))) / (lambda));
    }
    else
    {
      y = 0;
    }
    if (y > max)
    {
      max = y;
    }

    cout << y <<endl;
  }
  */
  for (int n = 0; n < count; n++)
  {
    x = ((double)rand()) / RAND_MAX;
    if (x < 0.5)
    {
      y = (log(2 * x)) / (lambda);
    }
    else if (x > 0.5)
    {
      y = -((log(2 - (2 * x))) / (lambda));
    }
    else if (x = 0.5)
    {
      y = 0;
    }

    cout << y <<endl;
  }

  return 0;
}