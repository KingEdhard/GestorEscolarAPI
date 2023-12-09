import { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import PropTypes from 'prop-types';

export default function GestorEscolarList({ data, onCreate, onUpdate, onDelete }) {
    const [formData, setFormData] = useState({ id: '', nombre: '', descripcion: '' });
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
        setFormData({ id: '', nombre: '', descripcion: '' });
    };

    const handleEdit = (item) => {
        setEditingId(item.id);
        setFormData({
            id: item.id,
            nombre: item.nombre,
            descripcion: item.descripcion,
        });
    };

    const handleCancelEdit = () => {
        setEditingId(null);
        setFormData({ id: '', nombre: '', descripcion: '' });
    };

    return (
        <div className="container mx-auto p-4">
            <h2 className="text-2xl font-bold mb-4">Nuevo {name}</h2>
            <form
                onSubmit={handleSubmit}
                className="flex flex-col space-y-4 bg-gray-50 p-4 rounded-md shadow-md"
            >
                <div className="grid grid-cols-12 gap-4">
                    <input
                        type="text"
                        name="nombre"
                        placeholder="Nombre"
                        value={formData.nombre}
                        onChange={handleFormChange}
                        className="border border-gray-300 p-2 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 col-start-3 col-span-2"
                        required
                    />
                    <input
                        type="text"
                        name="descripcion"
                        placeholder="Descripción"
                        value={formData.descripcion}
                        onChange={handleFormChange}
                        className="border border-gray-300 p-2 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 col-start-6 col-span-2"
                        required
                    />
                    <button
                        type="submit"
                        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 border border-blue-700 rounded col-start-9 col-span-2"
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
            {data.map((item) => (
                <div key={item.id}>
                    <span>{item.nombre}</span>
                    <FontAwesomeIcon icon={faEdit} onClick={() => handleEdit(item)} />
                    <FontAwesomeIcon icon={faTrash} onClick={() => onDelete(item.id)} />
                </div>
            ))}
        </div>
    );
}

GestorEscolarList.propTypes = {
    data: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.number.isRequired,
        nombre: PropTypes.string.isRequired,
        descripcion: PropTypes.string.isRequired,
    })).isRequired,
    onCreate: PropTypes.func.isRequired,
    onUpdate: PropTypes.func.isRequired,
    onDelete: PropTypes.func.isRequired,
};
