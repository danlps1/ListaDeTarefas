import api from '@/services/api.ts'
import type { Tarefa } from '@/services/interfaces/TarefaInterface.ts'
import type {ResponseInterface} from "@/services/interfaces/ResponseInterface.ts";

export async function getTarefas(): Promise<ResponseInterface<Tarefa[]>> {
    const response = await api.get('/tarefa')
    return response.data
}

export async function getTarefaById(tarefaId: number): Promise<ResponseInterface<Tarefa>> {
    const response = await api.get(`/tarefa/${tarefaId}`)
    return response.data
}

export async function createTarefa(tarefa: Omit<Tarefa, 'id'>): Promise<ResponseInterface<Tarefa>> {
    const response = await api.post('/tarefa', tarefa)
    return response.data
}

export async function editTarefa(tarefa: Tarefa): Promise<ResponseInterface<Tarefa>> {
    const response = await api.put('/tarefa', tarefa)
    return response.data
}

export async function deletarTarefa(tarefaId: number): Promise<ResponseInterface<Tarefa>> {
    const response = await api.delete(`/tarefa/${tarefaId}`)
    return response.data
}
