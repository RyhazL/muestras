
package ejercicio;

//Clase alumno que contien las variables nombe, edad, y materias cursadas
public class Alumno {
    private String nomb;
    private int edad;
    private Materia[] materias;
    
    //Constructor de la clase, devemos pasar los parametros Nombre, Edad y Materia curzadas pra inicializarlo
    public Alumno(String Nombre, int Edad, Materia[] MateriasCursadas){
        this.nomb = Nombre;
        this.edad = Edad;
        this.materias = MateriasCursadas;
    }
    
    //GETs y SETs de las variables de la clase.
    public void setNombre(String Nombre){
        this.nomb = Nombre;
    }
    public String getNombre(){
        return this.nomb;
    }
    public void setEdad(int Edad){
        this.edad = Edad;
    }
    public int getEdad(){
        return this.edad;
    }
    
    //sumamos todas las notas obtenidas de "getNotas" a una variable llamada resultado
    //y la dividimos por le tamaño del arreglo que son la candida de noas para sacar dicho promedio.
    public int CalcularPromedio(){
        int resultado = 0;
        for(int i = 0; i>this.materias.length;i++){
            resultado = resultado + this.materias[i].getNota();
        }
        resultado = resultado / this.materias.length;
        return resultado;
    }
    public void AsignarMateria(Materia materia){
        
        //Pasamos por el arreglo de las materia curzadas, si se encuentra que ya se tiene una materia
        //con el mismo nombre usamos return para salir de la funcion.
        
        for(int i = 0; i<this.materias.length;i++){
            if(materia.getNombre() == this.materias[i].getNombre()){
                return;
            }
        }
        
        //el codigo solo pasara por aqui si no se encuentra conincidencias en la comparacion por los tanto
        //no hay una materia con el mismo nombre y devemos asignarala al arreglo y retornar true para decir
        //que si se asigno la materia nueva.
        int x;
        //nuevo arreglo que va a sustituir al viejo pues va a ser igual solo que con una materia extra.
        Materia[] nuevoarreglo = new Materia[this.materias.length + 1];
        for(x = 0; x<this.materias.length;x++){
            nuevoarreglo[x] = this.materias[x];
        }
        //agregamos la ultima materia que se va a agregar.
        nuevoarreglo[x] = materia;
        //y sustituimos nuestro anterio arreglo por por el nuevo y retornamos true.
        this.materias = nuevoarreglo;
    }
    
    //ya que las materias las pusimos como valores privados devemso imprimir desde aqui las materias.
    public void ImprimirMaterias(){
        
        for(int x = 0; x < this.materias.length; x++){
            System.out.println("    + "+ this.materias[x].getNombre());
            System.out.println("        Nota Final: " + this.materias[x].getNota());
            if(materias[x].Aprovado())
                System.out.println("        APROBADO");
            else
               System.out.println("        REPROBADO"); 
        }
    }
}
