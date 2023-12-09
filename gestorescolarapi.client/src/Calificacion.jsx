import { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import PropTypes from 'prop-types';

export default function Calificacion({ data, onCreate, onUpdate, onDelete }) {
    const [formData, setFormData] = useState({ id: '', valor: '', alumnoId: '', materiaId: '' });
    const [editingId, setEditingId] = useState(null);

    const handleFormChange = (event) => {
        const { name, value } = event.target;
        setFormData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        if (editingId) {
            onUpdate(formData);
            setEditingId(null);
        } else {
            onCreate(formData);
        }
        setFormData({ id: '', valor: '', alumnoId: '', materiaId: '' });
    };

    const handleEdit = (item) => {
        setEditingId(item.id);
        setFormData({
            id: item.id,
            valor: item.valor,
            alumnoId: item.alumnoId,
            materiaId: item.materiaId,
        });
    };

    const handleCancelEdit = () => {
        setEditingId(null);
        setFormData({ id: '', valor: '', alumnoId: '', materiaId: '' });
    };

    

    return (
        <div className="container mx-auto p-4 mb-8">
            <h2 className="text-2xl font-bold mb-4">Nueva Calificación</h2>
            <form
                onSubmit={handleSubmit}
                className=" flex flex-col space-y-4 bg-gray-50 p-4 rounded-md shadow-md"
            >
                <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-5 gap-4">
                    <input
                        type="number"
                        name="valor"
                        placeholder="Valor"
                        value={formData.valor}
                        onChange={handleFormChange}
                        className="border border-gray-300 p-2 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 "
                        required
                    />
                    <input
                        type="number"
                        name="alumnoId"
                        placeholder="ID del Alumno"
                        value={formData.alumnoId}
                        onChange={handleFormChange}
                        className="border border-gray-300 p-2 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 "
                        required
                    />
                    <input
                        type="number"
                        name="materiaId"
                        placeholder="ID de la Materia"
                        value={formData.materiaId}
                        onChange={handleFormChange}
                        className="border border-gray-300 p-2 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 "
                        required
                    />
                    <button
                        type="submit"
                        className=" bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 border border-blue-700 rounded "
                    >
                        {editingId ? 'Actualizar' : 'Crear'}
                    </button>
                    {editingId && (
                        <button
                            type="button"
                            onClick={handleCancelEdit}
                            className="bg-gray-500 text-white px-4 py-2 rounded-md hover:bg-gray-600"
                        >
                            Cancelar
                        </button>
                    )}
                </div>
            </form>
            <h2 className="text-2xl font-bold mt-4 mb-2">Calificaciones</h2>
            <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
                <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                    <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                        <tr>
                            <th scope="col" className="px-6 py-3">Valor</th>
                            <th scope="col" className="px-6 py-3">ID del Alumno</th>
                            <th scope="col" className="px-6 py-3">ID de la Materia</th>
                            <th scope="col" className="px-6 py-3"><span className="sr-only">Editar</span></th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.map((item) => (
                            <tr
                                key={item.id}
                                className="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600"
                            >
                                <td className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                                    {item.valor}
                                </td>
                                <td className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                                    {item.alumnoId}
                                </td>
                                <td className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                                    {item.materiaId}
                                </td>
                                <td className="px-6 py-4 text-right">
                                    <button
                                        onClick={() => handleEdit(item)}
                                        className="bg-blue-500 text-white px-2 py-1 rounded-md hover:bg-blue-600"
                                    >
                                        <FontAwesomeIcon icon={faEdit} />
                                    </button>
                                    <button
                                        onClick={() => onDelete(item.id)}
                                        className="bg-red-500 text-white px-2 py-1 rounded-md hover:bg-red-600 ml-2"
                                    >
                                        <FontAwesomeIcon icon={faTrash} />
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}

Calificacion.propTypes = {
    data: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.number.isRequired,
        valor: PropTypes.number.isRequired,
        alumnoId: PropTypes.number.isRequired,
        materiaId: PropTypes.number.isRequired,
    })).isRequired,
    onCreate: PropTypes.func.isRequired,
    onUpdate: PropTypes.func.isRequired,
    onDelete: PropTypes.func.isRequired,
};
