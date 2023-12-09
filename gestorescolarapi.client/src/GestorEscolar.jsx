import { useState, useEffect } from 'react';
import Profesor from './Profesor';
import Materia from './Materia';
import Alumno from './Alumno';
import Calificacion from './Calificacion';

export default function GestorEscolar() {
    const [data, setData] = useState({
        profesores: [],
        materias: [],
        alumnos: [],
        calificaciones: [],
    });

    // useEffect(() => {
    //   // Aquí es donde se haría la llamada a la API para obtener los datos
    //   // Por ahora, vamos a usar datos estáticos para simular la respuesta de la API
    //   const apiData = {
    //     profesores: [
    //       { id: 1, nombre: 'Profesor 1', departamento: 'Matemáticas' },
    //       { id: 2, nombre: 'Profesor 2', departamento: 'Ciencias' },
    //     ],
    //     materias: [
    //       { id: 1, nombre: 'Materia 1', semestre: '1', profesorId: 1 },
    //       { id: 2, nombre: 'Materia 2', semestre: '2', profesorId: 2 },
    //     ],
    //     alumnos: [
    //       { id: 1, nombre: 'Alumno 1', grado: '1' },
    //       { id: 2, nombre: 'Alumno 2', grado: '2' },
    //     ],
    //     calificaciones: [
    //       { id: 1, valor: 90, alumnoId: 1, materiaId: 1 },
    //       { id: 2, valor: 85, alumnoId: 2, materiaId: 2 },
    //     ],
    //   };
    //   setData(apiData);
    // }, []);


    // Llamada real de la API
    useEffect(() => {
        Promise.all([
            fetch('https://localhost:7126/api/Profesors').then(response => response.json()),
            fetch('https://localhost:7126/api/Materias').then(response => response.json()),
            fetch('https://localhost:7126/api/Alumnos').then(response => response.json()),
            fetch('https://localhost:7126/api/Calificacions').then(response => response.json())
        ])
            .then(([profesores, materias, alumnos, calificaciones]) => {
                setData({ profesores, materias, alumnos, calificaciones });
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }, []);




    // Aquí se agregan las funciones para manejar las operaciones CRUD
    // Por ejemplo, para crear un nuevo profesor:
    const handleCreateProfesor = (profesor) => {
        const newProfesor = { ...profesor, id: data.profesores.length + 1 };
        setData({ ...data, profesores: [...data.profesores, newProfesor] });
    };

    // Para actualizar un profesor:
    const handleUpdateProfesor = (profesor) => {
        setData((prevData) => ({
            ...prevData,
            profesores: prevData.profesores.map((item) =>
                item.id === profesor.id ? profesor : item
            ),
        }));
    };

    // Para borrar un profesor:
    const handleDeleteProfesor = (id) => {
        setData((prevData) => ({
            ...prevData,
            profesores: prevData.profesores.filter((item) => item.id !== id),
        }));
    };

    // Para crear una nueva materia:
    const handleCreateMateria = (materia) => {
        const newMateria = { ...materia, id: data.materias.length + 1 };
        setData({ ...data, materias: [...data.materias, newMateria] });
    };

    // Para actualizar una materia:
    const handleUpdateMateria = (materia) => {
        setData((prevData) => ({
            ...prevData,
            materias: prevData.materias.map((item) =>
                item.id === materia.id ? materia : item
            ),
        }));
    };

    // Para borrar una materia:
    const handleDeleteMateria = (id) => {
        setData((prevData) => ({
            ...prevData,
            materias: prevData.materias.filter((item) => item.id !== id),
        }));
    };

    // Para crear un nuevo alumno:
    const handleCreateAlumno = (alumno) => {
        const newAlumno = { ...alumno, id: data.alumnos.length + 1 };
        setData({ ...data, alumnos: [...data.alumnos, newAlumno] });
    };

    // Para actualizar un alumno:
    const handleUpdateAlumno = (alumno) => {
        setData((prevData) => ({
            ...prevData,
            alumnos: prevData.alumnos.map((item) =>
                item.id === alumno.id ? alumno : item
            ),
        }));
    };

    // Para borrar un alumno:
    const handleDeleteAlumno = (id) => {
        setData((prevData) => ({
            ...prevData,
            alumnos: prevData.alumnos.filter((item) => item.id !== id),
        }));
    };

    // Para crear una nueva calificación:
    const handleCreateCalificacion = (calificacion) => {
        const newCalificacion = { ...calificacion, id: data.calificaciones.length + 1 };
        setData({ ...data, calificaciones: [...data.calificaciones, newCalificacion] });
    };

    // Para actualizar una calificación:
    const handleUpdateCalificacion = (calificacion) => {
        setData((prevData) => ({
            ...prevData,
            calificaciones: prevData.calificaciones.map((item) =>
                item.id === calificacion.id ? calificacion : item
            ),
        }));
    };

    // Para borrar una calificación:
    const handleDeleteCalificacion = (id) => {
        setData((prevData) => ({
            ...prevData,
            calificaciones: prevData.calificaciones.filter((item) => item.id !== id),
        }));
    };

    return (
        <div>
            <Profesor
                data={data.profesores}
                onCreate={handleCreateProfesor}
                onUpdate={handleUpdateProfesor}
                onDelete={handleDeleteProfesor}
            />
            <Materia
                data={data.materias}
                onCreate={handleCreateMateria}
                onUpdate={handleUpdateMateria}
                onDelete={handleDeleteMateria}
            />
            <Alumno
                data={data.alumnos}
                onCreate={handleCreateAlumno}
                onUpdate={handleUpdateAlumno}
                onDelete={handleDeleteAlumno}
            />
            <Calificacion
                data={data.calificaciones}
                onCreate={handleCreateCalificacion}
                onUpdate={handleUpdateCalificacion}
                onDelete={handleDeleteCalificacion}
            />
        </div>
    );
}
