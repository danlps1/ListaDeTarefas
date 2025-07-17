import api from "@/services/api.ts";

export async function getTarefas() {
    const response = await api.get('/tarefa');
    return response.data;
}

export async function getTarefaById(tarefaId: number) {
    const response = await api.get(`/tarefa/${tarefaId}`);
    return response.data;
}

export async function createTarefa(tarefa: any) {
    const response = await api.post("/tarefa", tarefa);
    return response.data;
}

export async function editTarefa(tarefa: any) {
    const response = await api.put("/tarefa", tarefa);
    return response.data;
}

export async function deletarTarefa(tarefaId: number) {
    const response = await api.delete(`/tarefa/${tarefaId}`);
    return response.data;
}