<template>
  <v-app>
    <v-app-bar app>
      <v-toolbar-title class="headline text-uppercase">
        <router-link to="/" style="text-decoration: none; color: white"><span>POLL</span></router-link>
        <span class="font-weight-light">s</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <span class="mr-2"><login-form></login-form></span>
    </v-app-bar>

    <v-content>
      <HelloWorld/>
    </v-content>

  <Footer/>
  </v-app>
</template>

<script>
import HelloWorld from './components/HelloWorld';
import Footer from "./components/Footer";

export default {
  name: 'App',

  components: {
    Footer,
    HelloWorld
  },

  data: () => ({
    //
  }),
};
</script>
