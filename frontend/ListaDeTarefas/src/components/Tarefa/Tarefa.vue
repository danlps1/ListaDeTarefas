<template>
  <div class="min-h-screen bg-gray-100">
    <Header/>
    <main class="h-full w-full px-4 sm:px-0">
      <div class="flex justify-center flex-col items-center">
        <h1 class="text-4xl font-black text-gray-700 py-6">Gerenciamento de Tarefas</h1>
      </div>

      <div class="flex justify-center flex-col items-center">
        <div class="bg-white min-w-[600px] border border-gray-200 shadow-md rounded-md overflow-hidden">
          <div class="bg-gray-700 text-white w-full flex justify-center p-2 font-semibold text-lg">
            Tarefas Cadastradas
          </div>

          <div class="p-4" v-if="!tarefaStore.loading">
            <table class="min-w-full text-left text-sm">
              <thead class="text-xs uppercase bg-gray-200 text-gray-600">
              <tr>
                <th class="px-4 py-2">Usuário</th>
                <th class="px-4 py-2">Descrição</th>
                <th class="px-4 py-2">Completa</th>
                <th class="px-4 py-2 text-end">Ações</th>
              </tr>
              </thead>
              <tbody>
              <tr
                  v-for="tarefa in tarefaStore.tarefas"
                  :key="tarefa.id"
                  class="border-b hover:bg-gray-50"
              >
                <td class="px-4 py-2">{{ tarefa.usuarioId }}</td>
                <td class="px-4 py-2">{{ tarefa.tarefa }}</td>
                <td class="px-4 py-2">{{ tarefa.completa ? "Finalizada" : "Em progresso"}}</td>
                <td class="px-4 py-2 text-right space-x-2">
                  <button
                      class="bg-green-500 hover:bg-green-600 text-white px-3 py-1 rounded cursor-pointer"
                      @click="editarTarefa(tarefa)"
                  >
                    Editar
                  </button>
                  <button
                      class="bg-red-500 hover:bg-red-600 text-white px-3 py-1 rounded cursor-pointer"
                      @click="deletarTarefa(tarefa.id)"
                  >
                    Deletar
                  </button>
                </td>
              </tr>
              </tbody>
            </table>
            <p v-if="tarefaStore.tarefas.length === 0" class="text-center mt-4 text-gray-500">
              Nenhuma tarefa cadastrada.
            </p>
          </div>

          <div v-else class="p-4 text-center text-gray-600">Carregando...</div>
        </div>
        <p class="py-4 text-md text-gray-700">
          <router-link to="/tarefas/cadastrar">Cadastrar tarefa</router-link>
        </p>
        <p class="py-4 text-sm text-gray-700">
          <router-link to="/">Voltar</router-link>
        </p>
      </div>
    </main>
  </div>
</template>


<script lang="ts">
import {onMounted} from "vue";
import Header from "@/components/Header.vue";
import type {Tarefa} from "@/services/interfaces/TarefaInterface.ts";
import router from "@/router";
import {useTarefaStore} from "@/stores/tarefaStore.ts";

export default {
  components: {Header},
  setup() {
    const tarefaStore = useTarefaStore();

    const editarTarefa = (tarefa: Tarefa)=> {
      router.push(`/tarefas/editar/${tarefa.id}`)
    }

    const deletarTarefa = async (id: number): Promise<void> => {
      await tarefaStore.deletarTarefa(id);
      alert("Tarefa deletada.");
    }

    onMounted(async (): Promise<void> => {
      await tarefaStore.fetchTarefas();
    })

    return {
      tarefaStore,
      deletarTarefa,
      editarTarefa
    }
  }
}
</script>