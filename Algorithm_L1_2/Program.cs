using System;
using System.Collections.Generic;

namespace Algorithm_L1_2{

    internal class Program{

        static int numbersOfElements =300;
        static MainQueue<int> _queue = new MainQueue<int>();
        public static ulong N_op = 0;
     

        private class MainQueue<T> : Queue<T>{
            public void Push(T newValue){
                N_op++;
                Enqueue(newValue);   N_op += 3;
               
            }

            public T Pop(){
                return Dequeue();   N_op++;
            }

            public int Get(int pos){
                
                N_op++;
                int element = 0;    N_op++;
                for (int i = 0; i < numbersOfElements; i++){ N_op+=2;
                    
                    if (i == pos){ N_op++;
                        element = _queue.Pop(); N_op++;
                        _queue.Push(element);
                    }
                    else{ N_op++;
                        _queue.Push(_queue.Pop());
                    }
                }
                N_op+=2;
                N_op++;
                return element; 
            }
            
            public void Set(int pos, int newValue){

                for (int i = 0; i < numbersOfElements; i++){ N_op+=2;

                    if (i == pos){ N_op++;
                        _queue.Pop();
                        _queue.Push(newValue);
                    }
                    else{ N_op++;
                        _queue.Push(_queue.Pop());
                    }
                }
                N_op+=2;
            }
            
            public void Sort(){

                int step = numbersOfElements / 2;   N_op+=2;

                while (step >= 1){
                    N_op++;
                    
                    for (int i = step; i < numbersOfElements; i++){ N_op+=2;
                        int j = i; N_op++;

                        int firstElment = 0;    N_op++;
                        int secondElment = 0;   N_op++;

                        for (int k = 0; k < numbersOfElements; k++){ N_op+=2;
                            
                            if (k == j - step){     N_op+=2;
                                firstElment = _queue.Pop(); N_op++;
                                _queue.Push(firstElment);
                            }
                            else if (k == j){       N_op++;
                                secondElment = _queue.Pop();    N_op++;
                                _queue.Push(secondElment);
                            }
                            else{   N_op++;
                                _queue.Push(_queue.Pop());
                            }
                        }
                        
                        while (firstElment > secondElment && j >= step){    N_op+=3;
                            
                            for (int k = 0; k < j - step; k++){ N_op+=3;
                                
                                _queue.Push(_queue.Pop());
                            }   N_op+=3;

                            var save = _queue.Pop();  N_op++;

                            for (int k = 0; k < step - 1; k++){ N_op+=3;

                                _queue.Push(_queue.Pop());
                            }   N_op+=3;

                            _queue.Push(save);
                            save = _queue.Pop();    N_op++;

                            for (int k = 0; k < numbersOfElements - (step + 1); k++){   N_op+=4;

                                _queue.Push(_queue.Pop());
                            } N_op+=4;

                            _queue.Push(save);

                            for (int k = 0; k < numbersOfElements - (j - step + 1); k++){   N_op+=5;
                                
                                _queue.Push(_queue.Pop());
                            }   N_op+=5;

                            j = j - step; N_op+=2;

                            for (int k = 0; k < numbersOfElements; k++){  N_op+=2;

                                if (k == j - step){  N_op+=2;
                                    firstElment = _queue.Pop();  N_op++;
                                    _queue.Push(firstElment);
                                }
                                else if (k == j){   N_op++;
                                    secondElment = _queue.Pop(); N_op++;
                                    _queue.Push(secondElment);
                                }
                                else{   N_op++;
                                    _queue.Push(_queue.Pop());
                                }
                            }
                        }
                    }
                    
                    step = step / 2; N_op+=2;
                }
            }
        }

        public static void Main(string[] args){

            Random _random = new Random();

            for (int i = 0; i < 10; i++){

                for (int k = 0; k < numbersOfElements; k++){

                    _queue.Push(_random.Next(1, 10000));
                }
                
                var t_s = Environment.TickCount;
                _queue.Sort();
                var t_f = Environment.TickCount;
                
                Console.WriteLine(
                    $"Номер сортировки: {i + 1} Количетсво элементов: {numbersOfElements} Время сортировки (ms): {t_f - t_s} Кол-во операций(N_op): {N_op}");
                numbersOfElements += 300;
                N_op = 0;
            }
        }
    }
}
