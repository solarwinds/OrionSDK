(function () {
  var cache = {};

  function normPath(p) { return p ? p.replace(/\/?$/, '/') : '/'; }
  function currentPath() { return normPath(window.location.pathname); }

  /* ── Headings ── */

  function extractHeadings(doc, pageUrl) {
    var main = doc.querySelector('#main-content');
    if (!main) return [];
    var out = [];
    main.querySelectorAll('h2, h3').forEach(function (h) {
      if (h.id) out.push({ tag: h.tagName.toLowerCase(), text: h.textContent.trim(), anchor: pageUrl + '#' + h.id });
    });
    return out;
  }

  function renderHeadings(headings, ul) {
    ul.innerHTML = '';
    if (!headings.length) return;
    headings.forEach(function (h) {
      var li = document.createElement('li');
      var a = document.createElement('a');
      a.href = h.anchor;
      a.textContent = h.text;
      a.className = 'nav-heading-link nav-heading-' + h.tag;
      li.appendChild(a);
      ul.appendChild(li);
    });
  }

  function loadHeadings(pageUrl, ul) {
    if (ul.dataset.loaded) return;
    ul.dataset.loaded = '1';
    var norm = normPath(pageUrl);

    if (norm === currentPath()) {
      var hs = [];
      document.querySelectorAll('#main-content h2, #main-content h3').forEach(function (h) {
        if (h.id) hs.push({ tag: h.tagName.toLowerCase(), text: h.textContent.trim(), anchor: '#' + h.id });
      });
      cache[norm] = hs;
      renderHeadings(hs, ul);
      return;
    }

    if (cache[norm]) { renderHeadings(cache[norm], ul); return; }

    ul.innerHTML = '<li><span class="nav-loading">Loading…</span></li>';
    fetch(pageUrl)
      .then(function (r) { return r.text(); })
      .then(function (html) {
        var doc = new DOMParser().parseFromString(html, 'text/html');
        var hs = extractHeadings(doc, pageUrl);
        cache[norm] = hs;
        renderHeadings(hs, ul);
      })
      .catch(function () { ul.innerHTML = ''; ul.dataset.loaded = ''; });
  }

  /* ── Expand / Collapse ── */

  function toggle(li) {
    var wasOpen = li.classList.contains('open');
    li.classList.toggle('open');
    if (!wasOpen) {
      var pageUrl = li.dataset.pageUrl;
      var headingsUl = li.querySelector(':scope > .nav-headings');
      if (pageUrl && headingsUl) loadHeadings(pageUrl, headingsUl);
    }
  }

  document.querySelectorAll('.expand-btn').forEach(function (btn) {
    btn.addEventListener('click', function (e) {
      e.preventDefault();
      e.stopPropagation();
      var li = btn.closest('.nav-item, .nav-child');
      if (li) toggle(li);
    });
  });

  /* ── Auto-expand active item ── */

  (function autoExpand() {
    var activeChild = document.querySelector('.nav-child.active');
    if (activeChild) {
      var parent = activeChild.closest('.nav-item');
      if (parent) parent.classList.add('open');
      activeChild.classList.add('open');
      var ul = activeChild.querySelector(':scope > .nav-headings');
      if (ul && activeChild.dataset.pageUrl) loadHeadings(activeChild.dataset.pageUrl, ul);
      return;
    }
    var activeItem = document.querySelector('.nav-item.active');
    if (activeItem) {
      activeItem.classList.add('open');
      var ul2 = activeItem.querySelector(':scope > .nav-headings');
      if (ul2 && activeItem.dataset.pageUrl) loadHeadings(activeItem.dataset.pageUrl, ul2);
    }
  })();

  /* ── Search ── */

  var searchInput = document.getElementById('nav-search');
  var searchResults = document.getElementById('search-results');
  if (!searchInput || !searchResults) return;

  var searchIndex = null;
  var activeIdx = -1;
  var searchUrl = document.getElementById('sidebar').dataset.searchUrl;

  function fetchIndex() {
    if (searchIndex) return Promise.resolve(searchIndex);
    return fetch(searchUrl)
      .then(function (r) { return r.json(); })
      .then(function (data) { searchIndex = data; return data; });
  }

  function renderResults(results, q) {
    activeIdx = -1;
    if (!results.length) {
      searchResults.innerHTML = '<span class="search-no-results">No pages found</span>';
    } else {
      var escaped = q.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
      searchResults.innerHTML = results.slice(0, 20).map(function (p) {
        var hi = p.title.replace(new RegExp('(' + escaped + ')', 'gi'), '<strong>$1</strong>');
        return '<a class="search-result-item" href="' + p.url + '">' + hi + '</a>';
      }).join('');
    }
    searchResults.classList.add('visible');
  }

  function closeResults() {
    searchResults.classList.remove('visible');
    activeIdx = -1;
  }

  searchInput.addEventListener('input', function () {
    var q = searchInput.value.trim();
    if (!q) { closeResults(); return; }
    fetchIndex().then(function (idx) {
      var ql = q.toLowerCase();
      renderResults(idx.filter(function (p) { return p.title && p.title.toLowerCase().includes(ql); }), q);
    });
  });

  searchInput.addEventListener('keydown', function (e) {
    if (e.key === 'Escape') { searchInput.value = ''; closeResults(); return; }
    var items = searchResults.querySelectorAll('.search-result-item');
    if (!items.length) return;
    if (e.key === 'ArrowDown') {
      e.preventDefault();
      if (activeIdx >= 0) items[activeIdx].classList.remove('active');
      activeIdx = Math.min(activeIdx + 1, items.length - 1);
      items[activeIdx].classList.add('active');
    } else if (e.key === 'ArrowUp') {
      e.preventDefault();
      if (activeIdx >= 0) items[activeIdx].classList.remove('active');
      activeIdx = Math.max(activeIdx - 1, 0);
      items[activeIdx].classList.add('active');
    } else if (e.key === 'Enter' && activeIdx >= 0) {
      e.preventDefault();
      window.location.href = items[activeIdx].href;
    }
  });

  document.addEventListener('click', function (e) {
    if (!document.getElementById('nav-search-box').contains(e.target)) closeResults();
  });
})();
