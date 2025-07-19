<template>
  <div class="min-h-screen bg-gray-100">
    <header class="p-4 bg-gray-800 text-white">
      <div class="flex flex-row justify-between">
        <img src="../assets/logo.svg" width="30px" alt="Vue icon">
        <nav>
          <ul class="flex flex-row justify-around gap-4 mr-2 font-semibold">
            <li>
              <router-link to="/">HOME</router-link>
            </li>
            <li>
              <router-link to="/about">SOBRE</router-link>
            </li>
          </ul>
        </nav>
      </div>
    </header>

    <main class="h-full w-full">
      <div class="flex justify-center flex-col items-center">
        <h1 class="text-4xl font-black text-gray-700 py-3 mb-3 mt-3">Gereciamento de usuários</h1>
      </div>

      <div class="flex justify-center flex-col items-center">
        <div class="bg-white min-w-[600px] border-none rounded-md">
          <div class="bg-gray-700 text-white w-full flex flex-row justify-center p-1 font-semibold">
            <p class="p-1">Usuarios cadastrados no banco</p>
          </div>
          <div class="flex flex-col items-center py-3 bg-white">
            <ul>
              <li class="flex flex-row gap-2 justify-between">usuario -
                <button class="bg-green-500 border-none rounded-sm px-2 font-medium text-white">EDIT</button>
                <button class="bg-red-500 border-none rounded-sm px-2 font-medium text-white">DELETE</button>
              </li>
            </ul>
          </div>
        </div>
      </div>

    </main>
  </div>

</template>

<script>
export default {
  setup() {

  }
}
</script>