using System;
using System.Collections.Generic;

namespace Algorithm_L1_2{

    internal class Program{

        static int numbersOfElements =50;
        static MainQueue<int> _queue = new MainQueue<int>();
        public ulong N_op = 0;
     

        private class MainQueue<T> : Queue<T>{
            public void Push(T newValue){
                Enqueue(newValue);
            }

            public T Pop(){
                return Dequeue();
            }

            public int Get(int pos){

                int element = 0;
                for (int i = 0; i < numbersOfElements; i++){

                    if (i == pos){
                        element = _queue.Pop();
                        _queue.Push(element);
                    }
                    else{
                        _queue.Push(_queue.Pop());
                    }
                }

                return element;
            }
            
            public void Set(int pos, int newValue){

                for (int i = 0; i < numbersOfElements; i++){

                    if (i == pos){
                        _queue.Pop();
                        _queue.Push(newValue);
                    }
                    else{
                        _queue.Push(_queue.Pop());
                    }
                }
            }
            
            public void Sort(){

                int step = numbersOfElements / 2;

                while (step >= 1){ 
                    
                    for (int i = step; i < numbersOfElements; i++){
                        int j = i;

                        int firstElment = 0;
                        int secondElment = 0;

                        for (int k = 0; k < numbersOfElements; k++){
                            
                            if (k == j - step){
                                firstElment = _queue.Pop();
                                _queue.Push(firstElment);
                            }
                            else if (k == j){
                                secondElment = _queue.Pop();
                                _queue.Push(secondElment);
                            }
                            else{
                                _queue.Push(_queue.Pop());
                            }
                        }
                        
                        while (firstElment > secondElment && j >= step){
                           
                            for (int k = 0; k < j - step; k++){
                                
                                _queue.Push(_queue.Pop());
                            }

                            var save = _queue.Pop();

                            for (int k = 0; k < step - 1; k++){

                                _queue.Push(_queue.Pop());
                            }

                            _queue.Push(save);
                            save = _queue.Pop();

                            for (int k = 0; k < numbersOfElements - (step + 1); k++){

                                _queue.Push(_queue.Pop());
                            }

                            _queue.Push(save);

                            for (int k = 0; k < numbersOfElements - (j - step + 1); k++){
                                _queue.Push(_queue.Pop());
                            }

                            j = j - step;

                            for (int k = 0; k < numbersOfElements; k++){

                                if (k == j - step){
                                    firstElment = _queue.Pop();
                                    _queue.Push(firstElment);
                                }
                                else if (k == j){
                                    secondElment = _queue.Pop();
                                    _queue.Push(secondElment);
                                }
                                else{
                                    _queue.Push(_queue.Pop());
                                }
                            }
                        }
                    }
                    
                    step = step / 2;
                }
            }
        }

        public static void Main(string[] args){

            Random _random = new Random();

            for (int i = 0; i < 100000; i++){

                for (int k = 0; k < numbersOfElements; k++){

                    _queue.Push(_random.Next(1, 10000));
                }

                /*foreach (var t in _queue){
                    Console.Write(t + " ");
                }
                Console.WriteLine();*/
                var t_s = Environment.TickCount;
                _queue.Sort();
                var t_f = Environment.TickCount;
                /*foreach (var t in _queue){
                    Console.Write(t + " ");
                }
                Console.WriteLine();*/
                /*Console.WriteLine(
                    $"Номер сортировки: {i + 1} Количетсво элементов: {numbersOfElements} Время сортировки (ms): {t_f - t_s} Кол-во операций(N_op): {0}");*/
                //numbersOfElements += 1;
                
            }
        }
    }
}
