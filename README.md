# Image-cipher
Encrypts images (jpg, png) and writes to database

Проект на WinForms. 
Он зашифровывает коллекцию картинок формата .png и .jpg с помощью зараннее веденного клюса просто сдвигая ред пикселей по горизонтале в сторону, затем переводит в массив байтов и сохраняет в базе данных.
Класс [LockBitmap.cs](https://github.com/Yulian13/Image-cipher/blob/master/Photo%20cipher/Photo%20cipher/LockBitmap.cs) и медоды шифровки/дешифровки в классе [Librari.cs](https://github.com/Yulian13/Image-cipher/blob/master/Photo%20cipher/Photo%20cipher/Librari.cs) были целиком скопированны без изменений, главное что они работают.
Есть дополнительные функции для личного пользования.
