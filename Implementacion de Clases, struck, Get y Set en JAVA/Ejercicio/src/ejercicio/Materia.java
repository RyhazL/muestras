
package ejercicio;

//La clase Materia con variables privadas solo modificables desde afuera por los metodos get y set.
public class Materia {
    private String nomb;
    private int valor;
    
    //constructor de la clase Materia
    public Materia(String nombre, int nota){
        this.nomb = nombre;
        
        //Este codigo es ara restringir el valor entre 0 y 20 aun si metes valores mayores o menores
        if(nota < 0 ){
            this.valor = 0;
            return;
        }
        if(nota > 20){
            this.valor = 20;
            return;
        }
        if(nota >= 0 && nota <=20){
            this.valor = nota;
        }
    }
    
    //get para el nombre de la materia, que aunque no se nos pide, se nesesita a la hora de comparar
    //en la clase "Alumno" si la materia ya existe en el arreglo de dicha clase.
    public String getNombre(){
        return this.nomb;
    }
    //Metodo get para obtener la nota
    public int getNota(){
        return this.valor;
    }
    //Metodo set para asignar la nota
    public void setNota(int nota){
        
        //Lo mismo que en el contructor valor limitado a 0 y 20
        if(nota < 0 ){
            this.valor = 0;
            return;
        }
        if(nota > 20){
            this.valor = 20;
            return;
        }
        if(nota >= 0 && nota <=20){
            this.valor = nota;
        }
    }
    //Funcion boleana que nos devuelve Verdadero(es decir aprovado) si la nota es mayor o igual a 10
    //de lo contrario no manda Falso (No aprovado)
    public boolean Aprovado(){
        if(this.valor >= 10)
            return true;
        else
            return false;
    }
    
}
