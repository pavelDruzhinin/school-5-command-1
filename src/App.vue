<template>
  <v-app>
    <v-app-bar app>
      <v-toolbar-title class="headline text-uppercase">
        <router-link to="/" style="text-decoration: none; color: white">
          <span>POLL</span>
        </router-link>
        <span class="font-weight-light">s </span>
        <router-link to="/polls" style="text-decoration: none; color: white">
          <span>polls </span>
        </router-link>
        <router-link to="/admin" style="text-decoration: none; color: white">
          <span>admin </span>
        </router-link>
        <router-link to="/test" style="text-decoration: none; color: white">
          <span>test </span>
        </router-link>
      </v-toolbar-title>
      <v-spacer></v-spacer>
    </v-app-bar>

    <v-content>
      <router-view>
        <Index />
      </router-view>
    </v-content>

    <Footer />
  </v-app>
</template>

<script>
import Index from "./components/Index";
import Footer from "./components/Footer";

export default {
  name: "App",

  components: {
    Footer,
    Index
  },

  data: () => ({
    //
  })
};
</script>
