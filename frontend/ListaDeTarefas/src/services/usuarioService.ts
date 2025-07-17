import api from './api'
import type {ResponseInterface} from "@/services/interfaces/ResponseInterface.ts";
import type {Usuario} from "@/services/interfaces/UsuarioInterface.ts";

export async function getUsuarios(): Promise<ResponseInterface<Usuario[]>> {
    const response = await api.get('/usuario')
    return response.data
}

export async function getUsuarioById(id: number): Promise<ResponseInterface<Usuario>> {
    const response = await api.get(`/usuario/${id}`)
    return response.data
}

export async function createUsuario(usuario: Usuario): Promise<ResponseInterface<Usuario>> {
    const response = await api.post('/usuario', usuario)
    return response.data
}

export async function editUsuario(usuario: Usuario): Promise<ResponseInterface<Usuario>> {
    const response = await api.put('/usuario', usuario)
    return response.data
}

export async function deletarUsuario(id: number): Promise<ResponseInterface<Usuario>> {
    const response = await api.delete(`/usuario/${id}`)
    return response.data
}
