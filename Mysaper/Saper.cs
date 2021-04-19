using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Timers;

namespace Mysaper
{
    public partial class Saper : Form
    {
                // Объявление глобальных переменных //
        static System.Timers.Timer gametimer;
        static System.Timers.Timer timerstop;
      
        // Переменные таймера (Мин, Сек, Миллисек)
        static int min, sec, msec;

        // Переменные поля(Ширина, Высота, Размер клетки, Кол-во бомб)
        private static int width  = 10;
        private static int heigth = 10;
        private static int cellSize = 60;
        private static int widthhh = width * cellSize + 20;
        private static int heighttttt= heigth * cellSize + 73;
        
        private static int bombCount = 10;
        public static int Bombsleft = bombCount;
        static bool GameOver=false;

        // Скелет поля, Скелет меток, Массив кнопок, Массив изображений для клеток
        public static int[,] map = new int[heigth, width];
        public static int[,] marks = new int[heigth, width];
        public static Button[,] buttons = new Button[heigth, width];
        public static Image[] images = new Image[15];
        public static bool[,] btnEnabled = new bool[heigth, width];

        // Форма
        public static Form form;

        // Первый клик (Индикатор, Координаты клика)
        private static bool isFirstStep;
        private static Point firstCoord;

        // Пикчи
        public static Image pictureSet;
        
        public Saper()
        {
            InitializeComponent();
            Init(this);
        }
                // Создание элементов игры //
        // Размер окна приложения
        private static void ConfigureMapSize(Form current)
        {
            current.Width = widthhh;
            current.Height = heighttttt;
            //current.Width = width * cellSize + 20;
            //current.Height = heigth * cellSize + 73;
        }
        // Создание карты
        private static void InitMap()
        {
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = 0;
                }
            }
        }
        // Создание кнопок-квадратиков
        private static void InitButtons(Form current)
        {
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * cellSize, i * cellSize + 30);
                    button.Size = new Size(cellSize, cellSize);
                    button.Image = images[9];
                    button.MouseUp += new MouseEventHandler(OnButtonPressedMouse);
                    current.Controls.Add(button);

                    buttons[i, j] = button;
                    marks[i, j] = 0;
                    btnEnabled[i, j] = true;
                }
            }
        }
        // Создание всего вместе
        public static void Init(Form current)
        {  
            form = current;
            isFirstStep = true;
            pictureSet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "tiles2.png"));
            int i = 0;
            for(int j = 0; j < 3; j++)
            {
                for(int k = 0; k < 5; k++)
                {
                    images[i++] = FindNeededImage(k, j);
                }
            }
            /*images[0] = FindNeededImage(0, 0);
            images[1] = FindNeededImage(1, 0);
            images[2] = FindNeededImage(2, 0);
            images[3] = FindNeededImage(3, 0);
            images[4] = FindNeededImage(4, 0);
            images[5] = FindNeededImage(0, 1);
            images[6] = FindNeededImage(1, 1);
            images[7] = FindNeededImage(2, 1);
            images[8] = FindNeededImage(3, 1);
            images[9] = FindNeededImage(4, 1);
            images[10] = FindNeededImage(0, 2);
            images[11] = FindNeededImage(1, 2);
            images[12] = FindNeededImage(2, 2);
            images[13] = FindNeededImage(3, 2);*/
            ConfigureMapSize(current);
            InitMap();
            InitButtons(current);
        }
        // Инициализация таймера и количества бомб
        private void Saper_Load(object sender, EventArgs e)
        {
            gametimer = new System.Timers.Timer();
            gametimer.Interval = 10;
            gametimer.Elapsed += OnTimeEvent;
            gametimer.AutoReset = true;
            BombsLeft.Text = bombCount.ToString();
            timerstop = new System.Timers.Timer();
            timerstop.Interval = 100;
            timerstop.Elapsed += UpdateCounter;
            timerstop.Start();
        }
        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                msec += 1;
                if (msec == 62)
                {
                    msec = 0;
                    sec += 1;
                }
                if (sec == 60)
                {
                    sec = 0;
                    min += 1;
                }
                SaperTimer.Text = getTimer();
            }
            ));
        }
        private void UpdateCounter(object sender, ElapsedEventArgs e)
        {
            BombsLeft.Text = (bombCount - BombIsSelected()).ToString();
            SaperTimer.Text = getTimer();
        }
            // Генерация бомб
            private static void SeedMap()
            {
            Random r = new Random();
            int number = bombCount;
            for (int i = 0; i < number; i++)
            {
                int posI = r.Next(0, heigth);
                int posJ = r.Next(0, width);

                while (map[posI, posJ] == -1 || (Math.Abs(posI - firstCoord.Y) < 1 && Math.Abs(posJ - firstCoord.X) < 1))
                {
                    posI = r.Next(0, heigth);
                    posJ = r.Next(0, width);
                }
                map[posI, posJ] = -1;
            }
            }
        // Подсчет количества бомб и расстановка цифр на поле
        private static int CountCellBomb()
        {
            int sum = 0;
            for (int i = 0; i < heigth; i++) 
            {
                for (int j = 0; j < width; j++) 
                {
                    if (map[i, j] == -1)
                    {
                        sum++;
                        for (int k = i - 1; k < i + 2; k++) {
                            for (int l = j - 1; l < j + 2; l++) {
                                if (!IsInBorder(k, l) || map[k, l] == -1)
                                {
                                    continue;
                                }
                                map[k, l] += 1;
                            }
                        }
                    }
                }
            }
            return sum;
        }
                // Вспомогательные функции //
        // Открывает все бомбы
        private static void ShowAllBombs(int iBomb, int jBomb)
        {
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((i == iBomb && j == jBomb)) 
                    {
                        buttons[i, j].Image = images[11];

                    }
                    else if (map[i, j] == -1 && marks[i,j] == 0)
                    {
                        buttons[i, j].Image = images[13];
                    }
                    else if (map[i, j] != -1 && marks[i, j] != 0)
                    {
                        buttons[i, j].Image = images[14];
                    }
                }
            }
        }
        // Ставит на все бомбы флаги
        private static void MarkAllBombs()
        {
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[i, j] == -1)
                    {  
                        buttons[i, j].Image = images[10];
                        marks[i, j] = 1;
                    }
                }
            }
        }
        // "Вырезание" нужной части изображения
        public static Image FindNeededImage(int xPos, int yPos)
        {
            Image image = new Bitmap(cellSize, cellSize);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(pictureSet, new Rectangle(new Point(0, 0), new Size(cellSize, cellSize)), 0 + 32 * xPos, 0 + 32 * yPos, 33, 33, GraphicsUnit.Pixel);
            return image;
        }
        // Открыть одну клетку
        private static void OpenCell(int i, int j)
        {
           
            btnEnabled[i, j] = false;
            marks[i, j] = 0;
            switch (map[i, j])
            {
                case 1:
                    buttons[i, j].Image = images[1];
                    break;
                case 2:
                    buttons[i, j].Image = images[2];
                    break;
                case 3:
                    buttons[i, j].Image = images[3];
                    break;
                case 4:
                    buttons[i, j].Image = images[4];
                    break;
                case 5:
                    buttons[i, j].Image = images[5];
                    break;
                case 6:
                    buttons[i, j].Image = images[6];
                    break;
                case 7:
                    buttons[i, j].Image = images[7];
                    break;
                case 8:
                    buttons[i, j].Image = images[8];
                    break;
                case -1:
                    buttons[i, j].Image = images[11];
                    break;
                case 0:
                    buttons[i, j].Image = images[0];
                    break;

                default: break;
            }
        }
        //Подсчет выбранных бомб
        private static int BombIsSelected()
        {
            int sum = 0;
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (marks[i, j] == 1)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }
        //Открытие нескольких клеток
        private static void OpenCells(int i, int j)
        {
            OpenCell(i, j);
            if (map[i, j] == -1)
            {
                OnLose(i, j);
                return;
            }
            if (map[i, j] > 0)
            {
                return;
            }
            for (int k = i - 1; k < i + 2; k++)
            {
                for (int l = j - 1; l < j + 2; l++)
                {
                    if (!IsInBorder(k, l) || !btnEnabled[k, l])
                    {
                        continue;
                    }
                    if (map[k, l] == 0)
                    {
                        OpenCells(k, l);
                    }
                    else if (map[k, l] > 0)
                    {
                        OpenCell(k, l);
                    }
                }
            }
        }
        // Подсчет уже открытых клеток
        private static int OpenedCells()
        {
            int sum = 0;
            foreach (bool but in btnEnabled)
            {
                if (!but)
                {
                    sum++;
                }
            }
            return sum;
        }
        // Проверка правильности расстановки флагов
        private static bool flagCheck()
        {
            int flagsum = 0;
            int check = 0;
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (marks[i, j] == 1)
                    {
                        flagsum++;
                        if (map[i, j] == -1)
                        {
                            check++;
                        }
                    }

                }
            }
            return (check == bombCount && flagsum == bombCount);
        }
        // Проверка находится ли клетка на краю поля
        private static bool IsInBorder(int i, int j)
        {
            if (i < 0 || j < 0 || j > width - 1 || i > heigth - 1)
            {
                return false;
            }
            return true;
        }
        // Получение значения таймера и перевод его в строку
        private static string getTimer()
        {
            return string.Format("{0}:{1}.{2}", min.ToString().PadLeft(2, '0'), sec.ToString().PadLeft(2, '0'), msec.ToString().PadLeft(2, '0'));
        }
        // Событие на проигрыш
        private static void OnLose(int iButton, int jButton)
        {
            GameOver=true;
            ShowAllBombs(iButton, jButton);
            gametimer.Stop();
            //MessageBox.Show("Поражение!");//по нажатию на кнопку Да, выводить новую игру
            DialogResult res = MessageBox.Show("Начать заново?","Вы проиграли", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                resetGame();
                for (int i = 0; i < heigth; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        btnEnabled[i, j] = true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < heigth; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        btnEnabled[i, j] = false;
                    }
                }
            }
            //GameOver = true;
        }
        // Событие на победу
        private static void OnWin(int iButton, int jButton)
        {
            GameOver = true;
            MarkAllBombs();
            gametimer.Stop();
            File.AppendAllText("Records.txt", getTimer() + "\n");
            string[] records = File.ReadAllLines("Records.txt");
            Array.Sort(records);
            if (records.Length > 10) 
            {
                File.WriteAllText("Records.txt", "");
                for (int i = 0; i < 10; i++)
                {
                    File.AppendAllText("Records.txt", records[i] + "\n");
                }
            } else
            {
                File.WriteAllLines("Records.txt", records);
            }

            //MessageBox.Show("Вы победили, ура!");
            DialogResult res = MessageBox.Show("Желаете сыграть еще раз?", "Ура, вы победили!", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                resetGame();
                for (int i = 0; i < heigth; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        btnEnabled[i, j] = true;
                    }
                }
            }
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    btnEnabled[i, j] = false;
                }
            }
            //GameOver = true;
        }
        // Сброс параметров игры
        private static void resetGame()
        { 
            min = 0;
            sec = 0;
            msec = 0;   
            foreach (Button but in buttons)
            {
                form.Controls.Remove(but);
            }
            map = new int[heigth, width];
            buttons = new Button[heigth, width];
            marks = new int[heigth, width];
            btnEnabled = new bool[heigth, width];
            GameOver = false;
            cellSize = 60;
            if (heigth > 12 || width > 25)
                cellSize = 50;
            if (heigth > 15 || width > 30)
                cellSize = 40;
            if (heigth > 18 || width > 38)
                cellSize = 30;
            if (heigth > 25 || width > 50)
                cellSize = 20;
            Init(form);
        }
                // Обработка кнопок мыши //
        private static void OnButtonPressedMouse(object sender, MouseEventArgs e)
        {
            Button pressedButton = sender as Button;
            switch (e.Button.ToString())
            {
                case "Right":
                    OnRightButtonPressed(pressedButton);
                    break;
                case "Left":
                    OnLeftButtonPressed(pressedButton);
                    break;
                case "Middle":
                    OnMiddleButtonPressed(pressedButton);
                    break;
            }
        }
        // Событие нажатия ПКМ
        private static void OnRightButtonPressed(Button pressedButton)
        {
            int iButton = (pressedButton.Location.Y-30) / cellSize;
            int jButton = pressedButton.Location.X / cellSize;
            if (!btnEnabled[iButton, jButton])
            {
                return;
            } 
            marks[iButton, jButton]++;
            marks[iButton, jButton] %= 3;
            switch (marks[iButton, jButton])
            {
                case 0:
                    pressedButton.Image = images[9];
                    break;
                case 1:
                    pressedButton.Image = images[10];
                    break;
                case 2:
                    pressedButton.Image = images[12];
                    break;
            }
            if (marks[iButton, jButton] != 2)
            {
                if (flagCheck())
                {
                    OnWin(iButton, jButton);
                }
            } 
        }
        // Событие нажатия ЛКМ
        private static void OnLeftButtonPressed(Button pressedButton)
        {
            int iButton = (pressedButton.Location.Y - 30) / cellSize;
            int jButton = pressedButton.Location.X / cellSize;
            if (isFirstStep)
            {
                firstCoord = new Point(jButton, iButton);
                SeedMap();
                bombCount = CountCellBomb();
                gametimer.Start();
                isFirstStep = false;
            }
            if (marks[iButton, jButton] == 0 && GameOver==false)
            {
                OpenCells(iButton, jButton);
                if (map[iButton, jButton] > -1)
                {
                    if (OpenedCells() == heigth * width - bombCount)
                    {
                        OnWin(iButton, jButton);
                        return;
                    }
                }
            }
        }
        // Событие нажатия СКМ
        private static void OnMiddleButtonPressed(Button pressedButton)
        {
            int iButton = (pressedButton.Location.Y-30) / cellSize;
            int jButton = pressedButton.Location.X / cellSize;
            if (btnEnabled[iButton, jButton] || GameOver)
            {
                return;
            }
            int sum = 0;
            for(int i = iButton - 1; i < iButton + 2; i++)
            {
                for(int j = jButton - 1; j < jButton + 2; j++)
                {
                    if(IsInBorder(i, j))
                    {
                        if(marks[i, j] == 1)
                        {
                            sum++;
                        }
                    }
                }
            }
            if(sum > map[iButton, jButton])
            {
                for (int i = iButton - 1; i < iButton + 2; i++)
                {
                    for (int j = jButton - 1; j < jButton + 2; j++)
                    {
                        if (IsInBorder(i, j))
                        {
                            if (marks[i, j] == 1 && map[i, j] == -1)
                            {
                                OpenCell(i, j);
                                OnLose(i, j);
                                return;
                            }
                        }
                    }
                }
            } else if(sum == map[iButton, jButton])
            {
                for (int i = iButton - 1; i < iButton + 2; i++)
                {
                    for (int j = jButton - 1; j < jButton + 2; j++)
                    {
                        if (IsInBorder(i, j))
                        {
                            if ((marks[i, j] == 1 && map[i, j] != -1) || (marks[i, j] != 1 && map[i, j] == -1))
                            {
                                OpenCell(i, j);
                                OnLose(i,j);
                                return;
                            }
                            if (marks[i, j] == 1 && map[i, j] == -1)
                            {
                                continue;
                            }
                            OpenCells(i, j);
                        }
                    }
                }
            }
        }
                // Обработка кнопок окна //
        // Кнопка новой игры
        private void NewGame_Click(object sender, EventArgs e)
        {
            SaperTimer.Text = "00:00.00";
            BombsLeft.Text = bombCount.ToString();
            gametimer.Stop();
            resetGame();
        }
        // Кнопка применения настроек
        private void OkBtn_Click(object sender, EventArgs e)
        {
            SaperTimer.Text = "00:00.00";
            BombsLeft.Text = bombCount.ToString();
            bool flag;
            do
            {
                try
                {
                    heigth = int.Parse(MapHeight.Text);
                    width = int.Parse(MapWidth.Text);
                    bombCount = int.Parse(Bombs.Text);
                    flag = true;
                }
                catch (FormatException)
                {
                    flag = false;
                    MapHeight.Text = heigth.ToString();
                    MapWidth.Text = width.ToString();
                    Bombs.Text = bombCount.ToString();
                    MessageBox.Show("Неверно введены значения полей");
                }
            } while (!flag);

            if (heigth > 37)
            {
                heigth = 37;
            }
            if (width > 78)
            {
                width = 78;
            }
            if (heigth < 1)
            {
                if(heigth == 0) 
                {
                    heigth = 1;
                } 
                else
                {
                    heigth *= -1;
                }
            }
            if (width < 7)
            {
                width = 7;
            }
            if(bombCount < 1)
            {
                if(bombCount == 0)
                {
                    bombCount = 1;
                }
                else
                {
                    bombCount *= -1;
                }
            }
            if (bombCount > heigth * width - 1)
            {
                bombCount = heigth * width - 1;
            }
            
            gametimer.Stop();
            MapWidth.Text = width.ToString();
            MapHeight.Text = heigth.ToString();
            Bombs.Text = bombCount.ToString();
            resetGame();
        }
        // Кнопка рекордов
        private void HighRecords_Click(object sender, EventArgs e)
        {
            Record rec = new Record();
            rec.Show();
        }
        // Кнопка настроек
        private void MapSize_Click(object sender, EventArgs e)
        {
            MapHeight.Text = heigth.ToString();
            MapWidth.Text = width.ToString();
            Bombs.Text = bombCount.ToString();
        }
        // Кнопка инофрмации об игре
        private void About_Click(object sender, EventArgs e)
        {
            About form = new About();
            form.Show();
        }
        // Кнопка выхода
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }    
    }
}