import { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import PropTypes from 'prop-types';

export default function Alumno({ data, onCreate, onUpdate, onDelete }) {
    const [formData, setFormData] = useState({ id: '', nombre: '', grado: '' });
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
        setFormData({ id: '', nombre: '', grado: '' });
    };

    const handleEdit = (item) => {
        setEditingId(item.id);
        setFormData({
            id: item.id,
            nombre: item.nombre,
            grado: item.grado,
        });
    };

    const handleCancelEdit = () => {
        setEditingId(null);
        setFormData({ id: '', nombre: '', grado: '' });
    };

    

    return (
        <div className="container mx-auto p-4 mb-8">
            <h2 className="text-2xl font-bold mb-4">Nuevo Alumno</h2>
            <form
                onSubmit={handleSubmit}
                className="flex flex-col  space-y-4 bg-gray-50 p-4 rounded-md shadow-md"
            >
                <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4">
                    <input
                        type="text"
                        name="nombre"
                        placeholder="Nombre"
                        value={formData.nombre}
                        onChange={handleFormChange}
                        className="border border-gray-300 p-2 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 "
                        required
                    />
                    <input
                        type="text"
                        name="grado"
                        placeholder="Grado"
                        value={formData.grado}
                        onChange={handleFormChange}
                        className="border border-gray-300 p-2 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 "
                        required
                    />
                    <button
                        type="submit"
                        className=" bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-5 border border-blue-700 rounded  "
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
            <h2 className="text-2xl font-bold mt-4 mb-2">Alumnos</h2>
            <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
                <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                    <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                        <tr>
                            <th scope="col" className="px-6 py-3">Nombre</th>
                            <th scope="col" className="px-6 py-3">Grado</th>
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
                                    {item.nombre}
                                </td>
                                <td className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                                    {item.grado}
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

Alumno.propTypes = {
    data: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.number.isRequired,
        nombre: PropTypes.string.isRequired,
        grado: PropTypes.string.isRequired,
    })).isRequired,
    onCreate: PropTypes.func.isRequired,
    onUpdate: PropTypes.func.isRequired,
    onDelete: PropTypes.func.isRequired,
};
