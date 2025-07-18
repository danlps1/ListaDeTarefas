<template>
  <div class="min-h-screen bg-gray-100 flex items-center justify-center px-4">
    <div class="bg-white rounded-2xl shadow-2xl p-10 w-full max-w-xl text-center">
      <h1 class="text-4xl font-bold text-blue-600">Lista de Tarefas</h1>
      <p class="text-gray-600 mt-2">Gerencie suas tarefas e usuários com facilidade</p>

      <div class="flex gap-6 mt-5 justify-center">
        <router-link
            to="/usuarios"
            class="px-6 py-3 bg-blue-500 text-white rounded-xl shadow-md hover:bg-blue-600 transition"
        >
          Usuários
        </router-link>
        <router-link
            to="/tarefas"
            class="px-6 py-3 bg-green-500 text-white rounded-xl shadow-md hover:bg-green-600 transition"
        >
          Tarefas
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  setup() {

  }
}
</script>
