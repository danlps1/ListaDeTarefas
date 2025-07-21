<template>
  <div class="min-h-screen bg-gray-100">
    <Header/>
    <main class="h-full w-full px-4 sm:px-0">
      <div class="flex justify-center flex-col items-center">
        <h1 class="text-4xl font-black text-gray-700 py-6">Editar Tarefa</h1>
      </div>

      <div class="flex justify-center flex-col items-center">
        <div class="bg-white min-w-[600px] border border-gray-200 shadow-md rounded-md overflow-hidden">
          <div class="bg-gray-700 text-white w-full flex justify-center p-2 font-semibold text-lg">
            Formulário de edição
          </div>
          <div class="flex flex-col items-center p-4">
            <form @submit.prevent class="flex flex-col items-center">
              <label class="font-medium mb-1">Alterar descrição da Tarefa</label>
              <input type="text"
                     class="text-center bg-gray-200 border-none rounded-sm px-2 py-1 min-w-[250px] focus:outline-none text-sm"
                     maxlength="80"
                     v-model="descricaoTarefa"
              >
              <label class="font-medium mb-1">Tarefa finalizada?</label>
              <select
                  v-model="completaTarefa"
                  class="text-center bg-gray-200 border-none rounded-sm px-2 py-1 min-w-[100px] focus:outline-none text-sm"
              >
                <option :value="true">Sim</option>
                <option :value="false">Não</option>
              </select>
            </form>
            <button
                type="submit"
                class="bg-green-500 font-semibold hover:bg-green-600 text-white px-2 py-1 border-none rounded-sm mt-3 cursor-pointer "
                @click="editarUsuario()"
            >
              Editar
            </button>
          </div>
        </div>
        <p class="py-4 text-md text-gray-700">
          <router-link to="/tarefas">Voltar</router-link>
        </p>
      </div>
    </main>
  </div>
</template>

<script lang="ts">
import {useRoute} from "vue-router";
import Header from "@/components/Header.vue";
import {onMounted, ref} from "vue";
import {useTarefaStore} from "@/stores/tarefaStore.ts";
import type {Tarefa} from "@/services/interfaces/TarefaInterface.ts";
import router from "@/router";

export default {
  components: {Header},
  setup() {
    const route = useRoute();
    const tarefaStore = useTarefaStore();
    const tarefaId = Number(route.params.tarefaId);
    const descricaoTarefa = ref<string>()
    const completaTarefa = ref<boolean>(false);

    const editarUsuario = async (): Promise<void> => {
      try {
        const tarefa: Tarefa = {
          tarefa: descricaoTarefa.value,
          completa: completaTarefa.value,
          id: tarefaId
        };
        await tarefaStore.editTarefa(tarefa);
        setTimeout(() => {
          alert("Tarefa editada.");
          router.push('/tarefas');
        }, 500);
      } catch {
        alert("Erro ao editar tarefa.")
      } finally {
        descricaoTarefa.value = "";
      }
    }


    onMounted(async (): Promise<void> => {
      await tarefaStore.buscarTarefaPorId(tarefaId);
      descricaoTarefa.value = tarefaStore.tarefaSelecionada?.tarefa;
      completaTarefa.value = tarefaStore.tarefaSelecionada.completa;
    })

    return {
      descricaoTarefa,
      completaTarefa,
      tarefaStore,
      editarUsuario
    }
  }
}
</script>