#include <iostream>
#include <time.h>
#include <stdlib.h>
#include <math.h>
#include <vector>
#include <algorithm>
using namespace std;

int Partition(vector<double>& v, int start, int end) {

  int pivot = end;
  int j = start;
  for (int i = start; i < end; ++i) {
    if (v[i] < v[pivot]) {
      swap(v[i], v[j]);
      ++j;
    }
  }
  swap(v[j], v[pivot]);
  return j;

}

void Quicksort(vector<double>& v, int start, int end) {

  if (start < end) {
    int p = Partition(v, start, end);
    Quicksort(v, start, p - 1);
    Quicksort(v, p + 1, end);
  }

}

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
  vector<double> sortRes(count);

  double x = 0;
  double y = 0;

  double x_ = 0;
  double S_2 = 0;
  double me_ = 0;
  double R = 0;
  
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
    else if (x == 0.5)
    {
      y = 0;
    }
    res[n] = y;
    sortRes[n] = y;
    x_ += y;
    //cout << y <<endl;
  }

  for (int n = 0; n < count; n++)
  {
    S_2 += (res[n] - (x_ / count)) * (res[n] - (x_ / count));
  }

  S_2 = S_2 / count;

  Quicksort(sortRes, 0, sortRes.size() - 1);

  if (count % 2 == 0)
  {
    me_ = (sortRes[(count-1) / 2] + sortRes[((count-1) / 2) + 1]) / 2;
  }
  else
  {
    me_ = (sortRes[(((count - 1) / 2))]);
  }

  cout << endl;
  cout << "Матожидание = 0" << endl;
  cout << "Выборочное среднее = " << x_/count << endl;
  cout << "Отклонение от матожидания = " << (-1) * (x_ / count) << endl;
  cout << "Дисперсия случайной величины = " << 2 / ((lambda) * (lambda)) << endl;
  cout << "Выборочная дисперсия случайной величины = " << S_2 << endl;
  cout << "Отклонение от дисперсии = " << abs((2 / ((lambda) * (lambda)))-S_2) << endl;
  cout << "Выборочная медиана = " << me_ << endl;
  cout << "Размах выборки = " << sortRes[count - 1] - sortRes[0] << endl << endl;


  cout << sortRes[0] << endl;

  for (int n = 1; n < count; n++)
  {
    cout << sortRes[n] << endl;
    cout << sortRes[n] << endl;
  }

  cout << endl;
  cout << 1 / double(count) << endl;
  for (int n = 1; n < count; n++)
  {
    cout << n / double(count) << endl;
    cout << (n+1) / double(count) << endl;
  }




  return 0;
}