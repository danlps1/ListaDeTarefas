import api from "@/services/api.ts";

export async function getUsuarios() {
    const response = await api.get('/usuario');
    return response.data;
}

export async function getUsuariosById(usuarioId: number) {
    const response = await api.get(`/usuario/${usuarioId}`)
    return response.data;
}


export async function createUsuario(usuario: any) {
    const response = await api.post("/usuario", usuario)
    return response.data;
}

export async function editUsuario(usuario: any) {
    const response = await api.put("/usuario", usuario);
    return response.data;
}

export async function deletarUsuario(usuarioId: number) {
    const response = await api.delete(`/usuario/${usuarioId}`);
    return response.data;
}