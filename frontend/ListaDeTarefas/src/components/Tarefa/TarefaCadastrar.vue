<template>
  <div class="min-h-screen bg-gray-100">
    <Header/>
    <main class="h-full w-full px-4 sm:px-0">
      <div class="flex justify-center flex-col items-center">
        <h1 class="text-4xl font-black text-gray-700 py-6">Cadastrar Tarefa</h1>
      </div>

      <div class="flex justify-center flex-col items-center">
        <div class="bg-white min-w-[600px] border border-gray-200 shadow-md rounded-md overflow-hidden">
          <div class="bg-gray-700 text-white w-full flex justify-center p-2 font-semibold text-lg">
            Formulário de cadastro
          </div>
          <div class="flex flex-col items-center p-4">
            <form @submit.prevent class="flex flex-col items-center">
              <label class="font-medium mb-1">Descrição da tarefa: </label>
              <input type="text"
                     class="text-center bg-gray-200 border-none rounded-sm px-2 py-1 min-w-[250px] focus:outline-none text-sm"
                     maxlength="80"
                     v-model="descricaoTarefa"
              >
              <label class="font-medium mb-1">Id do usuário: </label>
              <input type="number"
                     class="text-center bg-gray-200 border-none rounded-sm px-2 py-1 min-w-[250px] focus:outline-none text-sm"
                     v-model="usuarioId"
              >
            </form>
            <button
                type="submit"
                class="bg-green-500 font-semibold hover:bg-green-600 text-white px-2 py-1 border-none rounded-sm mt-3 cursor-pointer "
                @click="cadastrarTarefa()"
            >
              Cadastrar
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
import Header from "@/components/Header.vue";
import router from "@/router";
import {ref} from "vue";
import type {Tarefa} from "@/services/interfaces/TarefaInterface.ts";
import {useTarefaStore} from "@/stores/tarefaStore.ts";
import {useUsuarioStore} from "@/stores/usuarioStore.ts";

export default {
  components: {Header},
  setup: function () {
    const tarefaStore = useTarefaStore();
    const usuarioStore = useUsuarioStore();
    const descricaoTarefa = ref<string>("");
    const usuarioId = ref<number>(0);

    const cadastrarTarefa = async (): Promise<void> => {
      try {

        await usuarioStore.buscarUsuarioPorId(usuarioId.value);
        const usuario = usuarioStore.usuarioSelecionado;

        const tarefa: Tarefa = {
          tarefa: descricaoTarefa.value,
          completa: false,
          usuarioId: usuario?.id,
          id: 1
        };

        await tarefaStore.addTarefa(tarefa);

        setTimeout(() => {
          alert("Tarefa cadastrada.");
          router.push('/tarefas');
        }, 500);
      } catch {
        if (!usuarioStore.usuarioSelecionado) {
          alert("Usuário não encontrado.");
        }
        alert("O campo descrição é obrigatório.")
      } finally {
        descricaoTarefa.value = "";
      }
    };

    return {
      tarefaStore,
      cadastrarTarefa,
      descricaoTarefa,
      usuarioId
    }
  }
}
</script>