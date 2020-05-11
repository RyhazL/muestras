/*
   
 */
package ejercicio;


public class Ejercicio {

    //Punto de entrada de la aplicacion
    public static void main(String[] args) {
        
        //Declararemos varias clases para reducir codigo, cuando les vallamso asignando materia a cada uno
        //Iremos cambiando valores con lso get y set.
        
        Materia matematica = new Materia("Matematica",20);
        Materia fisica = new Materia("Fisica",20);
        Materia quimica = new Materia("Quimica",20);
        Materia programacion = new Materia("Programacion",20);
        Materia matematica2 = new Materia("MatematicaII",20);
        Materia literatura = new Materia("Literatura",20);
        
        //Arrelgo donde meteremso a los alumnos para hacer un for y ahorrar codigo al final.
        Alumno[] alumnos = new Alumno[3];
        
        
        //asignemosle 3 materias a pedro: Matematica(17),Fisica(13),Programacion(15)
        Materia[] matPedro = new Materia[3];
        matematica.setNota(17);
        fisica.setNota(13);
        programacion.setNota(15);
        //Metamoslas en el arreglo.
        matPedro[0] = matematica;
        matPedro[1] = fisica;
        matPedro[2] = programacion;
        //por ultimo creamos el alumno pedro y pasamos su nombre edad y materias al contructor
        //y al arreglo de alumnos
        alumnos[0] = new Alumno("Pedro",17, matPedro);
        
        //Ahora aremos exactaente lo mismo con 2 alumnos mas
        
        Materia[] matMiguel = new Materia[2];
        matematica2.setNota(20);
        literatura.setNota(3);
        
        matMiguel[0] = matematica2;
        matMiguel[1] = literatura;
        
        alumnos[1] = new Alumno("Miguel",21,matMiguel);
                
        Materia[] matRamon = new Materia[3];
        fisica.setNota(4);
        quimica.setNota(10);
        literatura.setNota(8);
        
        matRamon[0] = quimica;
        matRamon[1] = literatura;
        matRamon[2] = fisica;
        
        alumnos[2] = new Alumno("Ramon",30,matRamon);
        
        //vamos a asignar unas cuantas materias
        //a miguel que tien 2 materias le vamos a asignar fisica asi que en vez de dos
        //cando se imprima el tendra 3 materias en vez de 2.
        alumnos[1].AsignarMateria(fisica);
        
        //a ramon lo volveremos a asignar quimica, peor como el ya tiene quimica no se asigna asi que
        //sequira teniendo 3 materias
        alumnos[2].AsignarMateria(quimica);
        
        
        //Los meteremso todos en un arreglo parahacer un for y reducir codigo.
        
        //Ahora pasamos a mostar los datos pedidos con la funcion printIn
        
        for(int x = 0; x < alumnos.length; x++){
            System.out.println("Alumno numero: "+(x+1));
            System.out.println("- Nombre: " + alumnos[x].getNombre());
            System.out.println("- Edad: " + alumnos[x].getEdad());
            System.out.println("- Materias:");
            alumnos[x].ImprimirMaterias();
        }
        
    }
    
}

/*
EJERCICIO PRACTICO: MATERIAS VISTAS en grupo de 2 personas  Implementar la clase Materia que represente el nombre de una asignatura y la nota obtenida del 1 a 20 puntos. Implemente los siguientes métodos.
Constructor que acepte como parámetros el nombre de la materia y la nota obtenida.
Métodos para modificar la nota (setNota) y para consultar la nota (getNota).
Método que nos devuelva “Aprobado” si la nota es mayor o igual a 10 o “Reprobado” si la nota es menor que 10.
Método para consultar el nombre de la materia.
1.	Implementar la clase Alumno que incluya un array de sus materias vistas. Además de incluir los atributos nombre y edad. Implemente los siguientes métodos:
Constructor que acepte como parámetro el nombre del alumno y edad.
Métodos para modificar el nombre (setNombre) y para consultarlo (getNombre).
Métodos para modificar y consultar la edad.
Método que nos devuelva el promedio del alumno.
Método para adicionar una materia; verificar que la materia no esté ya en el arreglo de este Alumno.
2.	Implementar la clase materia para hacer uso de las clases Alumno y materia.
•	Crear tres instancias de la clase Alumno con sus respectivos nombre y edad.
•	Para cada alumno establecer sus materias con la nota correspondiente.
•	Mostrar en pantalla:
1.	Datos del Alumno
2.	Materias que cursó:
	Nombre de la materia.
	Nota obtenida.
	Si es una materia aprobada o no.
3.	Promedio del alumno
ENTREGAR INFORME CON:
ENUNCIADO – EXPLICACION CLARA DE LAS CLASES DEFINIDAS – CODIGO COMENTADO  EN JAVA IMPRESO Y EN DIGITAL – MOSTRAR CORRIDA(S) EJEMPLOS
*/