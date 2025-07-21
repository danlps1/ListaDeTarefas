<template>
  <header class="p-4 bg-gray-800 text-white">
    <div class="flex flex-row justify-between">
      <a href="https://vuejs.org/" target="_blank">
        <img src="../assets/logo.svg" width="30px" alt="Vue icon">
      </a>
      <nav>
        <ul class="flex flex-row justify-around gap-4 mr-2 font-semibold">
          <li>
            <router-link to="/">HOME</router-link>
          </li>
        </ul>
      </nav>
    </div>
  </header>
</template>
<script>
export default {
  setup() {
  }
}
</script>