#include <iostream>
#include <time.h>
#include <stdlib.h>
#include <math.h>
#include <vector>
using namespace std;

int main()
{
  setlocale(LC_ALL, "rus");
  srand(time(0));
  double lambda;
  int count;

  cout << "Vvedite lambda ";
  cin >> lambda;
  cout << endl;

  cout << "Vvedite chislo opitov ";
  cin >> count;
  cout << endl;

  vector<double> res(count);

  double x = 0;
  double y = 0;

  double x_ = 0;
  double S_2 = 0;
  double me = 0;
  
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
    res[n] = y;
    x_ += y;
    cout << y <<endl;
  }

  for (int n = 0; n < count; n++)
  {
    S_2 += (res[n] - (x_ / count)) * (res[n] - (x_ / count));
  }

  S_2 = S_2 / count;

  cout << endl;
  cout << "Матожидание = 0" << endl;
  cout << "Выборочное среднее = " << x_/count << endl;
  cout << "Отклонение от матожидания = " << (-1) * (x_ / count) << endl;
  cout << "Дисперсия случайной величины = " << 2 / ((lambda) * (lambda)) << endl;
  cout << "Выборочная дисперсия случайной величины = " << S_2 << endl;
  cout << "Отклонение от дисперсии = " << abs((2 / ((lambda) * (lambda)))-S_2) << endl;

  return 0;
}