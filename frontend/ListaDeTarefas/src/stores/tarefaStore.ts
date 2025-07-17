import {defineStore} from 'pinia'
import {ref} from 'vue'
import type {Tarefa} from '@/services/interfaces/TarefaInterface.ts'
import * as tarefaService from '@/services/tarefaService.ts'

export const useTarefaStore = defineStore('tarefa', () => {
    const tarefas = ref<Tarefa[]>([])
    const tarefaSelecionada = ref<Tarefa | null>(null)
    const loading = ref(false)
    const error = ref<string | null>(null)

    const fetchTarefas = async (): Promise<void> => {
        loading.value = true
        error.value = null
        try {
            const res = await tarefaService.getTarefas()
            tarefas.value = res.dados ?? []
        } catch (e) {
            error.value = 'Erro ao buscar tarefas.'
            console.error(e)
        } finally {
            loading.value = false
        }
    }

    const buscarTarefaPorId = async (tarefaId: number): Promise<void> => {
        loading.value = true
        error.value = null
        try {
            const res = await tarefaService.getTarefaById(tarefaId)
            tarefaSelecionada.value = res.dados ?? null
        } catch (e) {
            error.value = 'Erro ao buscar tarefa.'
            console.error(e)
        } finally {
            loading.value = false
        }
    }

    const addTarefa = async (tarefa: Tarefa): Promise<void> => {
        await tarefaService.createTarefa(tarefa)
        await fetchTarefas()
    }

    const editTarefa = async (tarefa: Tarefa): Promise<void> => {
        await tarefaService.editTarefa(tarefa)
        await fetchTarefas()
    }

    const deletarTarefa = async (tarefaId: number): Promise<void> => {
        await tarefaService.deletarTarefa(tarefaId)
        await fetchTarefas()
    }

    return {
        tarefas,
        tarefaSelecionada,
        loading,
        error,
        fetchTarefas,
        buscarTarefaPorId,
        addTarefa,
        editTarefa,
        deletarTarefa
    }
})
